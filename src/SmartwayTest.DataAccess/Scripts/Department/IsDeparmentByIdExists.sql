SELECT EXISTS(
    SELECT id 
    FROM departments
    WHERE id = @id)