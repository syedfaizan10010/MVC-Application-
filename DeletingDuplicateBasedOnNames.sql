DELETE FROM Employee
WHERE EmpName IN (
  SELECT EmpName
  FROM Employee
  GROUP BY EmpName
  HAVING COUNT(*) > 1
);