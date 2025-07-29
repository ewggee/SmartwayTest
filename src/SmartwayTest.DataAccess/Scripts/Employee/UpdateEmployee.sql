UPDATE employees SET
    name = COALESCE(@name, name),
    surname = COALESCE(@surname, surname),
    phone = COALESCE(@phone, phone),
    company_id = COALESCE(@companyId, company_id),
    department_id = COALESCE(@departmentId, department_id)
WHERE id = @id