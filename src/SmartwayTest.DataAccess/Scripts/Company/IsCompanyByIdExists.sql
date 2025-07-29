SELECT EXISTS(
    SELECT id 
    FROM companies
    WHERE id = @id)