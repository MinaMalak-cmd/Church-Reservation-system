/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [MassId]
      ,[Name]
      ,[maxCapacity]
      ,[currentSeats]
      ,[Date]
      ,[Duration]
  FROM [ReservationDB].[dbo].[Masses]
  select count(*) from People
  select * from Masses
  select * from People
  select P.*, M.* from People P join Masses M
  on P.MassId=M.MassId and P.MassId=3
  Delete  from Masses where MassId>3 and MassId<10
  Delete  from People  where Id>11

 DELETE FROM People  WHERE reservationDate  < DATEADD(day, -1, GETDATE())
 CREATE PROCEDURE DeleteOldReservations
 AS
   DELETE FROM People  WHERE reservationDate  < DATEADD(day, -1, GETDATE())
  GO
  Exec DeleteOldReservations

  DROP PROCEDURE DeleteOldReservations;  
GO  