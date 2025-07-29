SELECT EXISTS(
	SELECT id
	FROM employees
	WHERE id = @id)