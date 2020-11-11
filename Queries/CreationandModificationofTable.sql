
--UC1_Creation_of_EmployeePayroll_Service_Database
create database EmployeePayRoll_Service;

--UC2_Create_Employee_Payroll_Table
use EmployeePayRoll_Service;

create table Employee_PayRoll
(
EmployeeId int identity(1,1),
EmployeeName varchar(40) not null,
salary money,
StartDate date 
);


--UC3_InsertintoEmployeePayrollTable

insert into Employee_PayRoll values
('Bill',100000.00,'2018-01-03'),
('Terisa',200000.00,'2019-11-03'),
('Charlie',300000.00,'2020-05-21');



--UC4_Retrieve_Data_from_EmplyeeTable
select * from Employee_PayRoll;

--UC5_Retrieve_Data_Using_Condition
select * from Employee_PayRoll
where EmployeeName = 'Bill';

select * from Employee_PayRoll
where StartDate between CAST('2020-01-01' AS date) and GETDATE();

--UC6_Update_Existing_Rows_and_Add new_column
ALTER TABLE Employee_PayRoll
ADD gender char;

select * from Employee_PayRoll;

UPDATE Employee_PayRoll
SET gender = 'M'
where EmployeeName = 'Bill';

UPDATE Employee_PayRoll
SET gender = 'F'
where EmployeeName = 'Charlie';

UPDATE Employee_PayRoll
SET gender = 'F'
where EmployeeID = 2;


select * from Employee_PayRoll;



--UC7_Use_DB_Functions
SELECT gender, SUM(salary) FROM Employee_PayRoll
GROUP BY gender;

SELECT gender, MAX(salary) FROM Employee_PayRoll
GROUP BY gender;

SELECT gender, MIN(salary) FROM Employee_PayRoll
GROUP BY gender;

SELECT gender, AVG(salary) FROM employee_payroll
GROUP BY gender;

SELECT gender, COUNT(EmployeeID) FROM Employee_PayRoll
GROUP BY gender;



--UC8_Adding_more_attributes

alter table Employee_PayRoll add PhoneNumber varchar(15);
alter table Employee_PayRoll add Department varchar(50);

select * from Employee_PayRoll


alter table Employee_PayRoll add address varchar(150);
alter table employee_payroll add constraint df_address default 'India' for address

insert into employee_payroll (EmployeeName,salary,StartDate,gender) values
('Billi',200000.00,'2018-01-03','M')

select * from Employee_PayRoll


--UC9_Adding_More_Atributes

alter table Employee_PayRoll add
Deduction float,
Taxable_Pay real,
Income_Tax real;

select * from Employee_PayRoll

alter table Employee_PayRoll add
net_pay float;
select * from Employee_PayRoll


--UC10_Adding_Terissa_to_SalesandMarketing

insert into Employee_PayRoll (EmployeeName,salary,StartDate,gender,Department) values
('Terisa',200000.00,'2018-01-03','F','Sales')


insert into Employee_PayRoll (EmployeeName,salary,StartDate,gender,Department) values
('Terisa',200000.00,'2018-01-03','F','Marketing')




create procedure SpAddEmployeeDetails1
(
@EmployeeName varchar(255),
@Salary int,
@StartDate Date,
@Gender char(1),
@PhoneNumber varchar(12),
@Address varchar(255),
@Department varchar(25),
@BasicPay int,
@TaxablePay int,
@IncomeTax int,
@NetPay int
)
as
begin
insert into employee_payroll values
(
@EmployeeName,@Salary,@StartDate,@Gender,@PhoneNumber,@Address,@Department,@BasicPay,@TaxablePay,@IncomeTax,@NetPay
)
end


CREATE procedure spUpdateEmployeeSalary_
(
@id int,
@salary int,
@EmpID int

)
as
BEGIN
--below line will cause transaction uncommitable if constraint violation occur
set XACT_ABORT on;
begin try
begin TRANSACTION;
update Payroll
set Salary=@salary
where Id=@id;
select e.Id,e.Name,s.Salary
from Employee e inner join SALARY s
ON e.Id=s.Id where s.Id=@id;
COMMIT TRANSACTION;
END TRY
BEGIN CATCH
select ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
IF(XACT_STATE())=-1
BEGIN
  PRINT N'The transaction is in an uncommitable state.'+'Rolling back transaction.'
  ROLLBACK TRANSACTION;
  END;

  IF(XACT_STATE())=1
  BEGIN
    PRINT 
	    N'The transaction is committable. '+'Committing transaction.'
       COMMIT TRANSACTION;
	END;
	END CATCH
END


select count(EmployeeId) from Employee_PayRoll;