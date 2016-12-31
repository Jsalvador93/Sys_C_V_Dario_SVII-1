SELECT name, modify_date,create_date
FROM sys.objects
WHERE type = 'p' 
order by name asc


exec sp_rename @objName = '', @newname = @WrappedName, @objtype = 'P';

declare @sp varchar(1000)
set @sp = (SELECT  definition  
FROM sys.sql_modules
WHERE object_id = (OBJECT_ID(N'sp_list_Caj_Caja_listar')))    

print @sp


alter procedure sp_sel_Caj_Caja_seleccionar 
@i_idCaja int
as
begin
	select [i_idCaja],[b_ver],C.[dt_fchRegistro],[d_fchIngreso],[vc_dscpCaja],PV.[i_idPtoVenta], PV.vc_nombre , S.i_idSucursal , S.vc_dscpSucursal
	from [dbo].[Caj_Caja] C inner join [dbo].[Emp_Punto_Venta] PV on C.i_idPtoVenta=pv.i_idPtoVenta inner join Emp_Sucursal S 
		on PV.i_idSucursal = S.i_idSucursal
	where @i_idCaja= i_idCaja
end


alter function fn_getDate (@f date)
returns varchar(20)
as
begin
	return cast(day(@f) as varchar(2)) + '/' + cast(month(@f) as varchar(2)) + '/' + cast(year(@f) as varchar(4))
end

select dbo.fn_ParseDateTime('12/24/2017')

create function fn_getDateTime (@f datetime)
returns varchar(20)
as
begin
	return cast(day(@f) as varchar(2)) + '/' + cast(month(@f) as varchar(2)) + '/' + cast(year(@f) as varchar(4)) + ' ' + 
			cast( datepart(hour , @f ) as varchar(2)) + ':' + cast( datepart( minute , @f ) as varchar(2)) + ':' + cast( datepart( second , @f ) as varchar(2))
end

exec sp_configure 'default language'


GO
EXEC sp_configure 'default language', 5 ;
GO
RECONFIGURE ;
GO

select *
from Caj_Caja


--cambiar el nombre de la columna
EXEC sp_rename 'Caj_Caja.dt_fchIngreso', 'd_fchIngreso', 'column'; 

--cambiar el tipo de dato
ALTER TABLE Caj_Caja ALTER COLUMN d_fchIngreso date ; 


delete from Caj_Caja where i_idCaja > 5
