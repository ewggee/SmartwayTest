UPDATE employees SET
    name = COALESCE(@name, name),
    surname = COALESCE(@surname, surname),
    phone = COALESCE(@phone, phone),
    company_id = COALESCE(@company_Id, company_id),
    department_id = COALESCE(@department_Id, department_id)
WHERE id = @id