using System;
using System.Data;
using System.Linq;

using Dapper;

using Nancy;
using Nancy.ModelBinding;
using Nancy.Validation;

using SimplerWay.Models;

namespace SimplerWay
{
    public class EmployeeModule : NancyModule
    {
        private readonly IDbConnection _connection;

        public EmployeeModule(IDbConnection connection)
            : base("/employees")
        {
            _connection = connection;
            Get["/"] = _ =>
                connection.Query<EmployeeList>("select Id, Name from [Employee] order by Name")
                    .ToArray();
            Get["/{id}"] = GetEmployee;
            Post["/"] = CreateEmployee;
            Put["/"] = UpdateEmployeeName;
        }

        private object GetEmployee(dynamic parameters)
        {
            int id;

            if (!Int32.TryParse((string) parameters["id"], out id))
            {
                return HttpStatusCode.BadRequest;
            }

            var employee = _connection.Query<EmployeeDetails>("select Id, Name, Email from [Employee] where Id = @id", new { id })
                .FirstOrDefault();

            if (employee == null)
            {
                return HttpStatusCode.NotFound;
            }

            return employee;
        }

        private object CreateEmployee(dynamic parameters)
        {
            var createEmployee = this.BindAndValidate<CreateEmployee>();

            if (!ModelValidationResult.IsValid)
            {
                return HttpStatusCode.BadRequest;
            }

            var employeeId = _connection.ExecuteScalar<int>(
                "insert into [Employee] (Name, Email) output INSERTED.ID values (@Name, @Email)", createEmployee);

            return Response.AsJson(employeeId, HttpStatusCode.Created);
        }

        private object UpdateEmployeeName(dynamic parameters)
        {
            var updateEmployeeName = this.BindAndValidate<UpdateEmployeeName>();

            if (!ModelValidationResult.IsValid)
            {
                return HttpStatusCode.BadRequest;
            }

            if (string.IsNullOrWhiteSpace(updateEmployeeName.Name))
            {
                return HttpStatusCode.BadRequest;
            }

            var recordCount = _connection.Execute(
                "update [Employee] set Name = @Name where Id = @Id", updateEmployeeName);

            return recordCount == 1
                ? HttpStatusCode.OK
                : HttpStatusCode.NotFound;
        }
    }
}