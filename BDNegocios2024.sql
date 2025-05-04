use master
go

create database Negocios2024
use Negocios2024
go

create table tb_empleado(
idempleado int identity(1,1)primary key not null,
apeempleado varchar(100) not null
)
go
insert into tb_empleado
values
('Davolio'),
('Fuller'),
('Leverling'),
('Peacock'),
('Buchanan'),
('Suyama'),
('King'),
('Callahan'),
('Dodsworth')
go
create table tb_solicitud(
nsol varchar(7) primary key,
fsol datetime,
cliente varchar(100) not null,
dircliente varchar(255) not null,
idempleado int references tb_empleado,
monto decimal(10,2)
)
go
insert into tb_solicitud
values
('0000001', '2022-01-15', 'Carlos Pablo', 'Lima', 1, 100.50),
('0000002', '2022-05-20', 'Carlos Pineda', 'Lima', 2, 200.75),
('0000003', '2022-10-11', 'Gian Carlos', 'Lima', 3, 150.00),
('0000004', '2023-03-05', 'Daniela Perez', 'Lima', 4, 300.25),
('0000005', '2023-07-15', 'Mateo Martin', 'Lima', 5, 250.80),
('0000006', '2023-11-20', 'Felipe Castillo', 'Lima', 6, 125.60),
('0000007', '2024-02-12', 'Ana Juarez', 'Lima', 7, 400.00),
('0000008', '2024-06-10', 'Abigail Quispe', 'Lima', 8, 320.50),
('0000009', '2024-09-18', 'Kiara Rojas', 'Lima', 9, 275.90),
('0000010', '2024-12-01', 'Rodrigo Corzo', 'Lima', 1, 150.00)
go
--listar solicitudes
create procedure usp_listar_sol
as
begin
select * from tb_solicitud
end
go
--listar empleados
create procedure usp_listar_emp
as
begin
select * from tb_empleado
end
go
exec usp_listar_sol
exec usp_listar_emp
go
--consultar solicitud por empleado
create procedure usp_consultar_sol
@idempleado int
as
begin
select * from tb_solicitud
where idempleado = @idempleado
end
go


--insertar solicitud
create procedure usp_insertar_soli
@nsol VARCHAR(7),
@fsol DATETIME,
@cliente VARCHAR(100),
@dircliente VARCHAR(255),
@idempleado INT,
@monto DECIMAL(10, 2)
As
Begin
insert into tb_solicitud
values(@nsol, @fsol, @cliente, @dircliente,@idempleado,@monto)
print('Nueva solicitud Agregado')
End
go
exec usp_insertar_soli'0000012','2024-11-01','Ana Paredes','Lima',1,250.25
exec usp_listar_sol
