UPDATE passports SET
	type = COALESCE(@type, type),
	number = COALESCE(@number, number)
WHERE id = @id