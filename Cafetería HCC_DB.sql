--CREADO POR ADRIAN RAMIREZ SALAZAR

CREATE DATABASE HCC

USE HCC

CREATE TABLE HccOrdenes(
	 ord_id INT NOT NULL
	,mes_id INT NOT NULL
	,catord_id INT NOT NULL
	,ord_fecha_inicio DATE NOT NULL
	,ord_estatus TINYINT NOT NULL
	,PRIMARY KEY(ord_id)
	,CONSTRAINT fk_mesas FOREIGN KEY(mes_id) REFERENCES HccMesas(mes_id)
	,CONSTRAINT fk_catEstatusOrden FOREIGN KEY (catord_id) REFERENCES HccCatEstatusOrden(catord_id)
);

CREATE TABLE HccCatEstatusOrden(
	 catord_id INT NOT NULL
	,catord_nombre VARCHAR(50) NOT NULL
	,catord_estatus TINYINT NOT NULL
	,PRIMARY KEY(catord_id)
);

CREATE TABLE HccMesas(
	 mes_id INT NOT NULL
	,mes_lugares SMALLINT NOT NULL
	,mes_disponibles TINYINT NOT NULL
	,mes_estatus TINYINT NOT NULL
	,PRIMARY KEY(mes_id)
);

CREATE TABLE HccAlmacen(
	 alm_id INT NOT NULL
	,alm_cantidad INT NOT NULL
	,alm_fecha_actualizacion DATE NOT NULL
	,alm_estatus TINYINT NOT NULL
	,PRIMARY KEY(alm_id)
);

CREATE TABLE HccProductos(
	 pro_id INT NOT NULL
	,alm_id INT NOT NULL
	,pro_nombre VARCHAR(50) NOT NULL
	,pro_descripcion VARCHAR(120) NOT NULL
	,pro_precio DECIMAL(10,4) NOT NULL
	,pro_estatus TINYINT NOT NULL
	,PRIMARY KEY(pro_id)
	,CONSTRAINT fk_almacen FOREIGN KEY (alm_id) REFERENCES HccAlmacen(alm_id)
);

CREATE TABLE Hcc_OrdenesDetalle(
	 orddet_id INT NOT NULL
	,ord_id INT NOT NULL
	,pro_id INT NOT NULL
	,orddet_cantidad SMALLINT NOT NULL
	,orddet_estatus TINYINT NOT NULL
	,PRIMARY KEY(orddet_id)
	,CONSTRAINT fk_ordenes FOREIGN KEY (ord_id) REFERENCES HccOrdenes(ord_id)
	,CONSTRAINT fk_productos FOREIGN KEY (pro_id) REFERENCES HccProductos(pro_id)
);


