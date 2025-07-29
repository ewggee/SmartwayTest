SELECT 
	e.name, 
	e.surname, 
	e.phone, 
	e.company_id,
	p.type, 
	p.number, 
	d.name,
	d.phone
FROM employees e
	LEFT JOIN passports p ON e.passport_id = p.id
	LEFT JOIN departments d ON e.department_id = d.id
WHERE e.company_id = @company_id