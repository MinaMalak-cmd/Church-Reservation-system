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