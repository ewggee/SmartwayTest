SELECT EXISTS(
    SELECT id 
    FROM passports
    WHERE type = @type AND number = @number)