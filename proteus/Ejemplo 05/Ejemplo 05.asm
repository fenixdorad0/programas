;	05-06-06
;	Ejemplo 05
;	Luces del Auto fantastico - optimizado
;	PIC 16f84a
;	MPLAB 7.30
;	PROTEUS 6.9 SP3
;	Veguepic

	LIST	P=16F84A,				; usar PIC 16F84A
	#include <p16f84A.inc>

	__CONFIG _CP_OFF&_PWRTE_ON&_WDT_OFF&_XT_OSC	; code protec		off
							; power up timer	on
							; watchdog		off
							; osc			XT

PDel0	equ	0C
PDel1	equ	0D

	ORG	0
	BSF	STATUS,5				; activa la pagina 1
	MOVLW	B'00000'				; carga 00000 en W
	MOVWF	TRISA					; puerto a todos salidas
	MOVLW	B'00000000'				; carga 00000000 en W
	MOVWF	TRISB					; puerto b todos salidaS
	BCF	STATUS,5				; volvemos a la pagina 0

	CLRF	PORTB					; ponemos a cero el puerto b

INICIO							; etiqueta
	BSF	PORTB,0					; prende RB0
	BCF	STATUS,0				; limpia el carry de STATUS,C
	
REPETIR

IZQ
	CALL	DEMORA					; demora de 100ms
	RLF	PORTB,1					; rota el contenido de portb a la derecha
	BTFSS	PORTB,7					; hasta que prenda RB7, luego se salta
	GOTO	IZQ					; una linea

DER
	CALL	DEMORA					; demora de 100 ms
	RRF	PORTB,1					; rota el contenido de portb a la izquierda
	BTFSS	PORTB,0					; hasta que prenda RB0, luego salta
	GOTO	DER					; una linea

	GOTO	REPETIR					; repite el ciclo

	GOTO	INICIO					; va a inicio

;-------------------------------------------------------------
;	La demora a sido generada con el programa PDEL
;	Descripcion: Delay 100000 ciclos - 100 ms
;-------------------------------------------------------------
DEMORA  movlw     .110      ; 1 set numero de repeticion  (B)
        movwf     PDel0     ; 1 |
PLoop1  movlw     .181      ; 1 set numero de repeticion  (A)
        movwf     PDel1     ; 1 |
PLoop2  clrwdt              ; 1 clear watchdog
        clrwdt              ; 1 ciclo delay
        decfsz    PDel1, 1  ; 1 + (1) es el tiempo 0  ? (A)
        goto      PLoop2    ; 2 no, loop
        decfsz    PDel0,  1 ; 1 + (1) es el tiempo 0  ? (B)
        goto      PLoop1    ; 2 no, loop
PDelL1  goto PDelL2         ; 2 ciclos delay
PDelL2  goto PDelL3         ; 2 ciclos delay
PDelL3  clrwdt              ; 1 ciclo delay
        return              ; 2+2 Fin.
;-------------------------------------------------------------

	END						; fin de programa