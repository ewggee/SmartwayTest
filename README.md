# SmartwayTest
���������� ��������� ������� �������� Smartway

## ������������� �������
| �����  | ��������                          | ��������                                      |
|--------|-----------------------------------|-----------------------------------------------|
| POST   | `/api/employees`                  | ���������� ������ ����������. ���������� ID. |
| DELETE | `/api/employees/{id}`             | �������� ���������� �� ID.                   |
| GET    | `/api/company/{companyId}/employees` | ������ ���� ����������� ��������.           |
| GET    | `/api/company/{companyId}/departments/{departmentId}/employees` | ������ ����������� ������.              |
| PATCH  | `/api/employees/{id}`             | ��������� ���������� ������ ����������.      |

## ������
��� ������� �����:

1. ����������� �����������
```bash
git clone https://github.com/ewggee/SmartwayTest.git
```

2. ������� ���� .env � ����� �������, ���������� � �� ��������� ����������:
```text
DB_USER=postgres
DB_PASSWORD=postgres
DB_NAME=SmartwayTest
```

3. ��������� ���������:
```bash
docker-compose up
```

4. ������� �� ������:
- Swagger UI: http://localhost:8080/swagger
- �������� URL: http://localhost:8080/api