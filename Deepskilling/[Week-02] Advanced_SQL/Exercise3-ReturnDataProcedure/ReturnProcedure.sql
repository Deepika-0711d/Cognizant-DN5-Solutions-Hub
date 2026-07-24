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

DROP PROCEDURE IF EXISTS FetchEmployeesByDepartment;

DELIMITER $$

CREATE PROCEDURE FetchEmployeesByDepartment(
    IN dept_id INT,
    OUT total_emp INT,
    OUT avg_salary DECIMAL(10, 2)
)
BEGIN
    SELECT COUNT(*) INTO total_emp FROM employees WHERE department = (
        SELECT DISTINCT department FROM employees WHERE emp_id = dept_id LIMIT 1
    );
    
    SELECT AVG(salary) INTO avg_salary FROM employees WHERE department = (
        SELECT DISTINCT department FROM employees WHERE emp_id = dept_id LIMIT 1
    );
    
    SELECT 
        emp_id,
        emp_name,
        department,
        salary,
        hire_date
    FROM employees 
    WHERE department = (
        SELECT DISTINCT department FROM employees WHERE emp_id = dept_id LIMIT 1
    )
    ORDER BY salary DESC;
END$$

DELIMITER ;

SET @dept_id = 1;
SET @emp_count = 0;
SET @avg_sal = 0;

CALL FetchEmployeesByDepartment(@dept_id, @emp_count, @avg_sal);

SELECT @emp_count AS TotalEmployees, @avg_sal AS AverageSalary;

SELECT '---' AS Separator;

SET @dept_id = 4;
CALL FetchEmployeesByDepartment(@dept_id, @emp_count, @avg_sal);
SELECT @emp_count AS TotalEmployees, @avg_sal AS AverageSalary;
