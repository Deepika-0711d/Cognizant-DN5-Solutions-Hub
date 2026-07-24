CREATE DATABASE IF NOT EXISTS company_db;
USE company_db;

DROP TABLE IF EXISTS employees;

CREATE TABLE employees (
    emp_id INT PRIMARY KEY AUTO_INCREMENT,
    emp_name VARCHAR(100) NOT NULL,
    department VARCHAR(50) NOT NULL,
    salary DECIMAL(10, 2) NOT NULL,
    hire_date DATE NOT NULL
);

INSERT INTO employees (emp_name, department, salary, hire_date) VALUES
('Rajesh Kumar', 'IT', 65000, '2020-01-15'),
('Priya Singh', 'IT', 72000, '2019-03-20'),
('Amit Patel', 'IT', 68000, '2021-06-10'),
('Neha Sharma', 'HR', 55000, '2020-02-28'),
('Vikram Desai', 'HR', 60000, '2018-11-05'),
('Anaya Nair', 'Sales', 70000, '2020-05-12'),
('Sanjay Reddy', 'Sales', 75000, '2019-07-22'),
('Divya Gupta', 'Sales', 68000, '2021-01-30'),
('Harsh Malhotra', 'Finance', 62000, '2019-09-18'),
('Sneha Chopra', 'Finance', 58000, '2021-04-11');

DROP PROCEDURE IF EXISTS GetEmployeesByDept;

DELIMITER $$

CREATE PROCEDURE GetEmployeesByDept(IN deptName VARCHAR(50))
BEGIN
    SELECT 
        emp_id,
        emp_name,
        department,
        salary,
        hire_date
    FROM employees
    WHERE department = deptName
    ORDER BY salary DESC;
END$$

DELIMITER ;

CALL GetEmployeesByDept('IT');

SELECT '---' AS Separator;

CALL GetEmployeesByDept('Sales');

SELECT '---' AS Separator;

CALL GetEmployeesByDept('HR');
