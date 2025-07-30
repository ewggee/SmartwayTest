# SmartwayTest
Реализация тестового задания компании Smartway

## Реализованные функции
| Метод  | Эндпоинт                          | Описание                                      |
|--------|-----------------------------------|-----------------------------------------------|
| POST   | `/api/employees`                  | Добавление нового сотрудника. Возвращает ID. |
| DELETE | `/api/employees/{id}`             | Удаление сотрудника по ID.                   |
| GET    | `/api/company/{companyId}/employees` | Список всех сотрудников компании.           |
| GET    | `/api/company/{companyId}/departments/{departmentId}/employees` | Список сотрудников отдела.              |
| PATCH  | `/api/employees/{id}`             | Частичное обновление данных сотрудника.      |

## Запуск
Для запуска нужно:

1. Клонировать репозиторий
```bash
git clone https://github.com/ewggee/SmartwayTest.git
```

2. Создать файл .env в корне проекта, определить в нём следующие переменные:
```text
DB_USER=postgres
DB_PASSWORD=postgres
DB_NAME=SmartwayTest
```

3. Запустить контейнер:
```bash
docker-compose up
```

4. Перейти по ссылке:
- Swagger UI: http://localhost:8080/swagger
- Основной URL: http://localhost:8080/api