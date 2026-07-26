SELECT TOP (1000) [CustomerId]
      ,[CustomerName]
  FROM [Employee].[dbo].[Customer]


select * from EmployeeDetails where Salary>(Select AVG(Salary) from EmployeeDetails)

with CTE_Name as(
  Select * from EmployeeDetails
)

Select * from CTE_Name

Select * from (
Select *, DENSE_RANK() Over (Order by salary Desc) rn
from EmployeeDetails
) t
where rn=3

with RankedEmployees as
(
Select *,ROW_NUMBER() Over (partition by jobid order by salary desc) rn
from dbo.EmployeeDetails
)
select * 
from RankedEmployees
where rn=2

Select * 
from EmployeeDetails
Order by id
OFFSET 20 Rows fetch next 10 rows only

with selectCTE as
(
  select Salary,
         DENSE_RANK() Over (Order by salary Desc) as rnk  
		 from EmployeeDetails
		 where Salary is not null

)select Salary
from selectCTE where rnk=1


[ApiController]
[Route("api/[controller]")]
public class ProductController:ControllerBase
{
  [HttpGet]
  public IActionResult Get()
  {
    var products=new List<string>{"Laptop","Mobile"};
	return Ok(products)
  }
}