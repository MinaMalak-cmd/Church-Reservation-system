/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [MassId]
      ,[Name]
      ,[maxCapacity]
      ,[currentSeats]
      ,[Date]
      ,[Duration]
  FROM [ReservationDB].[dbo].[Masses]
  select * from Masses
  select count(*) from People
  select * from People
  select P.*, M.* from People P join Masses M
  on P.MassId=M.MassId and P.MassId=3
  Delete  from Masses where MassId>4
