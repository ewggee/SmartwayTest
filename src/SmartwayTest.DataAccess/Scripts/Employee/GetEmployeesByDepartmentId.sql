SELECT
	e.id,
	e.name, 
	e.surname, 
	e.phone, 
	e.company_id as CompanyId,
	p.type as PassportType,
	p.number as PassportNumber,
	d.name as DepartmentName,
	d.phone as DepartmentPhone
FROM employees e
	LEFT JOIN passports p ON e.passport_id = p.id
	LEFT JOIN departments d ON e.department_id = d.id
WHERE e.company_id = @company_id AND e.department_id = @department_id