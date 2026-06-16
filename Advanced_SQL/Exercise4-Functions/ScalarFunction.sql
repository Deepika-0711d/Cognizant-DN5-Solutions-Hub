CREATE DATABASE IF NOT EXISTS company_db;
USE company_db;

DROP TABLE IF EXISTS employees;

CREATE TABLE employees (
    emp_id INT PRIMARY KEY AUTO_INCREMENT,
    emp_name VARCHAR(100) NOT NULL,
    department VARCHAR(50) NOT NULL,
    monthly_salary DECIMAL(10, 2) NOT NULL,
    hire_date DATE NOT NULL
);

INSERT INTO employees (emp_name, department, monthly_salary, hire_date) VALUES
('Rajesh Kumar', 'IT', 5416.67, '2020-01-15'),
('Priya Singh', 'IT', 6000, '2019-03-20'),
('Amit Patel', 'IT', 5666.67, '2021-06-10'),
('Neha Sharma', 'HR', 4583.33, '2020-02-28'),
('Vikram Desai', 'HR', 5000, '2018-11-05'),
('Anaya Nair', 'Sales', 5833.33, '2020-05-12'),
('Sanjay Reddy', 'Sales', 6250, '2019-07-22'),
('Divya Gupta', 'Sales', 5666.67, '2021-01-30'),
('Harsh Malhotra', 'Finance', 5166.67, '2019-09-18'),
('Sneha Chopra', 'Finance', 4833.33, '2021-04-11');

DROP FUNCTION IF EXISTS CalculateAnnualSalary;

DELIMITER $$

CREATE FUNCTION CalculateAnnualSalary(monthly_sal DECIMAL(10, 2))
RETURNS DECIMAL(12, 2)
DETERMINISTIC
READS SQL DATA
BEGIN
    DECLARE annual_sal DECIMAL(12, 2);
    SET annual_sal = monthly_sal * 12;
    RETURN annual_sal;
END$$

DELIMITER ;

SELECT 
    emp_id,
    emp_name,
    department,
    monthly_salary,
    CalculateAnnualSalary(monthly_salary) AS annual_salary
FROM employees
ORDER BY annual_salary DESC;

SELECT '---' AS Separator;

SELECT 
    emp_name,
    department,
    CalculateAnnualSalary(monthly_salary) AS annual_salary
FROM employees
WHERE CalculateAnnualSalary(monthly_salary) > 70000
ORDER BY annual_salary DESC;
