| opcionDeCarga opcionDeCargaSub   remiseria1 nombreRemiseria valorKM condicionPrincipal condicionSub|

"**************** CREAMOS LA REMISERIA *******************************************"
nombreRemiseria:= 'CARDOSO'.
valorKM:= 150.
remiseria1:= Remiseria constructorRemiseriaValorKM: valorKM nombreRemiseria: nombreRemiseria.
remiseria1 cargaAutomatica.

"************************************* MENU PRINCIPAL ******************************************"
condicionPrincipal:= true.
[condicionPrincipal = true] whileTrue: [
			remiseria1 menuPrincipalRemiseria.
			opcionDeCarga:= (Prompter  prompt: 'INGRESE LA OPCION DESEADA DEL MENU').
		"******************** OPCION INCORRECTA ********************"
			(opcionDeCarga  = nil) ifTrue: [
					condicionPrincipal:= false.
			]
				ifFalse: [
					(opcionDeCarga asNumber > 13) ifTrue: [
							MessageBox warning: 'LA OPCION INGRESADA ES INCORRECTA'.
					]
								ifFalse: [
		"************** ''OPCION 0'' - SUBMENU CARGA DE DATOS **********************"
							condicionSub:= true.
							(opcionDeCarga = '0') ifTrue: [
									[condicionSub = true] whileTrue: [
												remiseria1 menuCargaDatos.
												opcionDeCargaSub:=(Prompter prompt: 'INGRESE LA OPCION DESEADA').
												(opcionDeCargaSub = nil )ifTrue: [
															condicionSub:=false.
												]
																ifFalse: [
																"*****************CARAGA CHOFERES **********************************"
																		(opcionDeCargaSub = '0') ifTrue: [
																						remiseria1 cargaDatosAgregarPersonal: opcionDeCargaSub asNumber
																		].
																"*****************CARGA EMPLEADOS*************************************"
																		(opcionDeCargaSub = '1') ifTrue: [
																						remiseria1 cargaDatosAgregarPersonal: opcionDeCargaSub asNumber
																		].
																"*****************CARGA VEHICULOS*************************************"
																		(opcionDeCargaSub = '2') ifTrue: [
																						remiseria1 cargarDatosAgregarAutomotor
																		].
																"*****************CARGA CLIENTES*************************************"
																		(opcionDeCargaSub = '3') ifTrue: [
																						remiseria1 cargarDatosAgregarUsuario
																		].
																"*****************OPCION VOLVER AL MENU PRINCIPAL**************"
																		(opcionDeCargaSub = '4') ifTrue: [
																						condicionSub:= false
																		].
																"****************OPCION INCORRECTA***********************************"
																		(opcionDeCargaSub > '4') ifTrue: [
																						MessageBox warning:'LA OPCION INGRESADA ES INCORRECTA'.
																		].
																"****************MENSAJE PARA SEGUIR CARGANDO*****************"
																		(condicionSub = true) ifTrue: [
																						condicionSub:= MessageBox confirm: 'DESEA SEGUIR CARGANDO?'.
																		]. 
												].
									].
							].

		"************* ''OPCION 1'' - ASOCIAMOS UN VEHICULO A UN CHOFER ************"
							(opcionDeCarga = '1') ifTrue: [
									remiseria1 cargarDatosAsociarChoferVehiculoRemiseria.
									MessageBox warning: 'SE CARGO CON EXITO'.
							].

		"**************** ''OPCION 2'' - ASIGNAR TURNO A CHOFER EN ESPERA **************"
							(opcionDeCarga = '2') ifTrue: [
									remiseria1 cargarDatosAsignarTurnoRemiseria.
									MessageBox warning: 'SE CARGO CON EXITO'.
							].

		"**************** ''OPCION 3'' - VER SIGUIENTE CHOFER EN LA COLA (EJEMPLO REJECT) ****"
							(opcionDeCarga = '3') ifTrue: [
									remiseria1 verSiguienteTurnoRemiseria.
									MessageBox warning: 'CONTINUAR'.
							].

		"***************** ''OPCION 4'' - CALCULAR DISTANCIA DE UN VIAJE ******************"
							(opcionDeCarga = '4') ifTrue: [
									remiseria1 cargarDatosCalcularDistanciaOrigen.
									MessageBox warning: 'CONTINUAR'.
							].

		"***************** ''OPCION 5'' - INICIAR UN VIAJE COMPLETO ***************************"
							(opcionDeCarga = '5') ifTrue: [
									remiseria1 cargarDatosIniciarViajeRemiseria.
									MessageBox warning: 'SE INICIO EL VIAJE CON EXITO'.
							].

		"***************** ''OPCION 6'' - FINALIZAR UN VIAJE INICIALIZADO *********************"
							(opcionDeCarga = '6') ifTrue: [	
									remiseria1 cargarDatosFinalizarViajeRemiseria.
									MessageBox warning: 'SE FINALIZO  EL VIAJE CON EXITO'.
							].

		"***************** ''OPCION 7'' - LISTAR TELEFONOS DE LOS CLIENTES (EJEMPLO DE COLLECT) ********"
							(opcionDeCarga = '7') ifTrue: [
									remiseria1 listarTelefonosClientes.
									MessageBox warning: 'CONTINUAR'.
							].

		"***************** ''OPCION 8'' - VIAJES A UNA MISMA LOCALIDAD (EJEMPLO DE SELLECT) *************"
							(opcionDeCarga = '8') ifTrue: [
									remiseria1 cargarDatosViajesAunaMismaLocalidad.
									MessageBox warning: 'CONTINUAR'.
							].

		"****************** ''OPCION 9'' - BUSCAR CLIENTE (EJEMPLO DETECT) **********************************************"
							(opcionDeCarga = '9') ifTrue: [
									remiseria1 cargarDatosBuscarCliente.
									MessageBox warning: 'CONTINUAR'.
							].		
								
		"******************** ''OPCION 10'' - LISTAR VEHICULOS POR AÑO (EJEMPLO SORTED COLLECTION) ********"
							(opcionDeCarga = '10') ifTrue: [
									op:= (Prompter prompt:'0: DE MENOR A MAYOR o 1: DE MAYOR A MENOR').
									remiseria1 listarVehiculos: op.
									continuar:= MessageBox warning: 'Pulse para continuar'. ].

		"******************** ''OPCION 11'' - MOSTRAR VIAJES INICIADOS ******************************************"
							(opcionDeCarga = '11') ifTrue: [
									remiseria1 imprimirViajesIniciados.
									continuar:= MessageBox warning: 'CONTINUAR'. 
							].

		"******************** ''OPCION 12'' - LUGARES FAVORITOS (EJEMPLO OCURRENCES OF)******************************************"
							(opcionDeCarga = '12') ifTrue: [
									remiseria1 lugaresFavoritos.
									continuar:= MessageBox warning: 'CONTINUAR'. 
							].

		"******************** ''OPCION 13'' - SALIR***********************************************************************"
							(opcionDeCarga = '13') ifTrue: [
									condicionPrincipal:=false
							].
						].
					].

].