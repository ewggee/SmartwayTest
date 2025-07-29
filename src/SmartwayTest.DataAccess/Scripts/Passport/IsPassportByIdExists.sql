SELECT EXISTS(
    SELECT id 
    FROM passports
    WHERE id = @id)