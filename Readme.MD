Setup:
1) Run db migrations

Test unit of work by:
1) Fire a post call to controller
2) Create exception by changing table name from DB. Change from Employees to <new-table-name> or Departments to <new-table-name>
3) Unit of work using context will be shown
