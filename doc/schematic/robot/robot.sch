EESchema Schematic File Version 4
LIBS:robot-cache
EELAYER 29 0
EELAYER END
$Descr A4 11693 8268
encoding utf-8
Sheet 1 1
Title ""
Date ""
Rev ""
Comp ""
Comment1 ""
Comment2 ""
Comment3 ""
Comment4 ""
$EndDescr
$Comp
L MCU_Module:Arduino_UNO_R3 A2
U 1 1 5CBB77F7
P 7300 3600
F 0 "A2" H 7300 4781 50  0000 C CNN
F 1 "Arduino_UNO_R3" H 7300 4690 50  0000 C CNN
F 2 "Module:Arduino_UNO_R3" H 7450 2550 50  0001 L CNN
F 3 "https://www.arduino.cc/en/Main/arduinoBoardUno" H 7100 4650 50  0001 C CNN
	1    7300 3600
	1    0    0    -1  
$EndComp
$Comp
L robot:BME280breakout U4
U 1 1 5CBD2A13
P 9350 2150
F 0 "U4" H 9408 2275 50  0000 C CNN
F 1 "BME280breakout" H 9408 2184 50  0000 C CNN
F 2 "" H 9350 2150 50  0001 C CNN
F 3 "" H 9350 2150 50  0001 C CNN
	1    9350 2150
	1    0    0    -1  
$EndComp
$Comp
L robot:LSM303C_breakout U5
U 1 1 5CBD3076
P 9550 3500
F 0 "U5" H 9525 3625 50  0000 C CNN
F 1 "LSM303C_breakout" H 9525 3534 50  0000 C CNN
F 2 "" H 9550 3500 50  0001 C CNN
F 3 "" H 9550 3500 50  0001 C CNN
	1    9550 3500
	1    0    0    -1  
$EndComp
$Comp
L robot:DC-DC_buck U6
U 1 1 5CBD361D
P 2450 1600
F 0 "U6" H 2400 1925 50  0000 C CNN
F 1 "DC-DC_buck" H 2400 1834 50  0000 C CNN
F 2 "" H 2350 1800 50  0001 C CNN
F 3 "" H 2350 1800 50  0001 C CNN
	1    2450 1600
	1    0    0    -1  
$EndComp
$Comp
L robot:RPi_3b+ U1
U 1 1 5CBD38D7
P 3800 2750
F 0 "U1" H 3875 3215 50  0000 C CNN
F 1 "RPi_3b+" H 3875 3124 50  0000 C CNN
F 2 "" H 3850 1700 50  0001 C CNN
F 3 "" H 3850 1700 50  0001 C CNN
	1    3800 2750
	1    0    0    -1  
$EndComp
Text GLabel 4650 2600 2    50   Input ~ 0
Arduino
Text GLabel 7200 4700 3    50   Input ~ 0
Arduino
Text GLabel 6800 3100 0    50   Input ~ 0
Arduino
Text GLabel 6800 3000 0    50   Input ~ 0
Arduino
Text GLabel 7500 2600 1    50   Input ~ 0
Arduino
$Comp
L power:+BATT #PWR?
U 1 1 5CBE5485
P 1150 1500
F 0 "#PWR?" H 1150 1350 50  0001 C CNN
F 1 "+BATT" H 1165 1673 50  0000 C CNN
F 2 "" H 1150 1500 50  0001 C CNN
F 3 "" H 1150 1500 50  0001 C CNN
	1    1150 1500
	1    0    0    -1  
$EndComp
$Comp
L power:-BATT #PWR?
U 1 1 5CBE5999
P 1150 1700
F 0 "#PWR?" H 1150 1550 50  0001 C CNN
F 1 "-BATT" H 1150 1850 50  0000 C CNN
F 2 "" H 1150 1700 50  0001 C CNN
F 3 "" H 1150 1700 50  0001 C CNN
	1    1150 1700
	1    0    0    -1  
$EndComp
$Comp
L robot:L298N_module U3
U 1 1 5CBE7604
P 5600 1150
F 0 "U3" H 5825 1265 50  0000 C CNN
F 1 "L298N_module" H 5825 1174 50  0000 C CNN
F 2 "" H 5600 1150 50  0001 C CNN
F 3 "" H 5600 1150 50  0001 C CNN
	1    5600 1150
	1    0    0    -1  
$EndComp
$Comp
L Motor:Motor_DC M1
U 1 1 5CBE8A46
P 4650 1350
F 0 "M1" H 4808 1346 50  0000 L CNN
F 1 "Motor_DC" H 4808 1255 50  0000 L CNN
F 2 "" H 4650 1260 50  0001 C CNN
F 3 "~" H 4650 1260 50  0001 C CNN
	1    4650 1350
	1    0    0    -1  
$EndComp
$Comp
L Motor:Motor_DC M2
U 1 1 5CBE91A7
P 7000 1450
F 0 "M2" H 7158 1446 50  0000 L CNN
F 1 "Motor_DC" H 7158 1355 50  0000 L CNN
F 2 "" H 7000 1360 50  0001 C CNN
F 3 "~" H 7000 1360 50  0001 C CNN
	1    7000 1450
	1    0    0    -1  
$EndComp
$Comp
L Device:C C1
U 1 1 5CBE94B6
P 4250 1400
F 0 "C1" H 4365 1446 50  0000 L CNN
F 1 "C" H 4365 1355 50  0000 L CNN
F 2 "" H 4288 1250 50  0001 C CNN
F 3 "~" H 4250 1400 50  0001 C CNN
	1    4250 1400
	1    0    0    -1  
$EndComp
$Comp
L Device:C C2
U 1 1 5CBE9D6C
P 6600 1500
F 0 "C2" H 6715 1546 50  0000 L CNN
F 1 "C" H 6715 1455 50  0000 L CNN
F 2 "" H 6638 1350 50  0001 C CNN
F 3 "~" H 6600 1500 50  0001 C CNN
	1    6600 1500
	1    0    0    -1  
$EndComp
Wire Wire Line
	7400 2600 7400 2250
Wire Wire Line
	7400 2250 8150 2250
Wire Wire Line
	8150 2250 8150 3700
Wire Wire Line
	8150 3700 9150 3700
Wire Wire Line
	7800 4000 8500 4000
Wire Wire Line
	8500 2550 8500 4000
Connection ~ 8500 4000
Wire Wire Line
	8500 4000 9150 4000
Wire Wire Line
	7800 4100 8250 4100
Wire Wire Line
	8850 4100 8850 3900
Wire Wire Line
	8850 3900 9150 3900
Wire Wire Line
	8250 4100 8250 2450
Connection ~ 8250 4100
Wire Wire Line
	8250 4100 8850 4100
Wire Wire Line
	7400 4700 7400 4800
Wire Wire Line
	7400 4800 8050 4800
Wire Wire Line
	8050 4800 8050 2350
Wire Wire Line
	8050 4800 9050 4800
Wire Wire Line
	9050 4800 9050 3800
Wire Wire Line
	9050 3800 9150 3800
Connection ~ 8050 4800
Wire Wire Line
	6450 1350 6600 1350
Wire Wire Line
	6600 1350 6600 1250
Wire Wire Line
	6600 1250 7000 1250
Connection ~ 6600 1350
Wire Wire Line
	6450 1650 6600 1650
Wire Wire Line
	6600 1650 6600 1750
Wire Wire Line
	6600 1750 7000 1750
Connection ~ 6600 1650
Wire Wire Line
	5200 1150 4650 1150
Wire Wire Line
	4650 1150 4250 1150
Wire Wire Line
	4250 1150 4250 1250
Connection ~ 4650 1150
Wire Wire Line
	5200 1650 4650 1650
Wire Wire Line
	4650 1650 4250 1650
Wire Wire Line
	4250 1650 4250 1550
Connection ~ 4650 1650
Wire Wire Line
	8150 2250 9100 2250
Connection ~ 8150 2250
Wire Wire Line
	8050 2350 9100 2350
Wire Wire Line
	8250 2450 9100 2450
Wire Wire Line
	8500 2550 9100 2550
Wire Wire Line
	6800 4000 5800 4000
Wire Wire Line
	6800 4100 6300 4100
Wire Wire Line
	6800 3800 5900 3800
Wire Wire Line
	6800 3900 6000 3900
Wire Wire Line
	6800 4200 6100 4200
Wire Wire Line
	6800 4300 6200 4300
Wire Wire Line
	3700 1050 3700 1950
Wire Wire Line
	3700 1950 5350 1950
Wire Wire Line
	5350 1950 5350 1900
Wire Wire Line
	3500 1200 3500 2100
Wire Wire Line
	3500 2100 5450 2100
$Comp
L Device:LED D2
U 1 1 5CCB8547
P 2350 4100
F 0 "D2" H 2343 4316 50  0000 C CNN
F 1 "Ready_LED" H 2343 4225 50  0000 C CNN
F 2 "" H 2350 4100 50  0001 C CNN
F 3 "~" H 2350 4100 50  0001 C CNN
	1    2350 4100
	1    0    0    -1  
$EndComp
$Comp
L Device:LED D3
U 1 1 5CCBBC55
P 2350 4450
F 0 "D3" H 2343 4666 50  0000 C CNN
F 1 "Running_LED" H 2343 4575 50  0000 C CNN
F 2 "" H 2350 4450 50  0001 C CNN
F 3 "~" H 2350 4450 50  0001 C CNN
	1    2350 4450
	1    0    0    -1  
$EndComp
Wire Wire Line
	2500 4100 3100 4100
Wire Wire Line
	3100 4200 2700 4200
Wire Wire Line
	2700 4200 2700 4450
Wire Wire Line
	2700 4450 2500 4450
$Comp
L power:GND #PWR?
U 1 1 5CCC0411
P 1700 5000
F 0 "#PWR?" H 1700 4750 50  0001 C CNN
F 1 "GND" H 1705 4827 50  0000 C CNN
F 2 "" H 1700 5000 50  0001 C CNN
F 3 "" H 1700 5000 50  0001 C CNN
	1    1700 5000
	1    0    0    -1  
$EndComp
$Comp
L robot:RPi_cam U7
U 1 1 5CCCFA59
P 5000 2900
F 0 "U7" H 4937 3025 50  0000 C CNN
F 1 "RPi_cam" H 4937 2934 50  0000 C CNN
F 2 "" H 5000 2900 50  0001 C CNN
F 3 "" H 5000 2900 50  0001 C CNN
	1    5000 2900
	1    0    0    -1  
$EndComp
Wire Wire Line
	3350 1500 3350 2200
Wire Wire Line
	5250 2200 5250 5350
Wire Wire Line
	4150 5350 4150 5250
Wire Wire Line
	2750 1500 3350 1500
Wire Wire Line
	2750 2800 3100 2800
Wire Wire Line
	2750 1700 2750 2800
$Comp
L Device:LED D1
U 1 1 5CE2E588
P 2350 3750
F 0 "D1" H 2343 3966 50  0000 C CNN
F 1 "See_Ball_LED" H 2343 3875 50  0000 C CNN
F 2 "" H 2350 3750 50  0001 C CNN
F 3 "~" H 2350 3750 50  0001 C CNN
	1    2350 3750
	1    0    0    -1  
$EndComp
$Comp
L Device:LED D4
U 1 1 5CE2EB7A
P 2350 4800
F 0 "D4" H 2343 5016 50  0000 C CNN
F 1 "FrameRate_LED" H 2343 4925 50  0000 C CNN
F 2 "" H 2350 4800 50  0001 C CNN
F 3 "~" H 2350 4800 50  0001 C CNN
	1    2350 4800
	1    0    0    -1  
$EndComp
$Comp
L Device:R R4
U 1 1 5CE2EEA2
P 1950 4800
F 0 "R4" V 1743 4800 50  0000 C CNN
F 1 "220" V 1834 4800 50  0000 C CNN
F 2 "" V 1880 4800 50  0001 C CNN
F 3 "~" H 1950 4800 50  0001 C CNN
	1    1950 4800
	0    1    1    0   
$EndComp
$Comp
L Device:R R1
U 1 1 5CE32863
P 1950 3750
F 0 "R1" V 1743 3750 50  0000 C CNN
F 1 "220" V 1834 3750 50  0000 C CNN
F 2 "" V 1880 3750 50  0001 C CNN
F 3 "~" H 1950 3750 50  0001 C CNN
	1    1950 3750
	0    1    1    0   
$EndComp
$Comp
L Device:R R2
U 1 1 5CE33095
P 1950 4100
F 0 "R2" V 1743 4100 50  0000 C CNN
F 1 "220" V 1834 4100 50  0000 C CNN
F 2 "" V 1880 4100 50  0001 C CNN
F 3 "~" H 1950 4100 50  0001 C CNN
	1    1950 4100
	0    1    1    0   
$EndComp
$Comp
L Device:R R3
U 1 1 5CE33492
P 1950 4450
F 0 "R3" V 1743 4450 50  0000 C CNN
F 1 "220" V 1834 4450 50  0000 C CNN
F 2 "" V 1880 4450 50  0001 C CNN
F 3 "~" H 1950 4450 50  0001 C CNN
	1    1950 4450
	0    1    1    0   
$EndComp
Wire Wire Line
	3100 4000 2700 4000
Wire Wire Line
	2700 4000 2700 3750
Wire Wire Line
	2700 3750 2500 3750
Wire Wire Line
	3100 4800 2500 4800
Wire Wire Line
	1800 4800 1700 4800
Wire Wire Line
	1700 4800 1700 5000
Wire Wire Line
	1800 4450 1700 4450
Wire Wire Line
	1700 4450 1700 4800
Connection ~ 1700 4800
Wire Wire Line
	1800 4100 1700 4100
Wire Wire Line
	1700 4100 1700 4450
Connection ~ 1700 4450
Wire Wire Line
	1800 3750 1700 3750
Wire Wire Line
	1700 3750 1700 4100
Connection ~ 1700 4100
Wire Wire Line
	2100 3750 2200 3750
Wire Wire Line
	2100 4100 2200 4100
Wire Wire Line
	2100 4450 2200 4450
Wire Wire Line
	2100 4800 2200 4800
Wire Wire Line
	2050 1500 2050 1200
Wire Wire Line
	2050 1200 3500 1200
Wire Wire Line
	2050 1700 1950 1700
Wire Wire Line
	1950 1700 1950 1050
Wire Wire Line
	1950 1050 3700 1050
Wire Wire Line
	1150 1500 1300 1500
Wire Wire Line
	5200 1400 5200 1150
Wire Wire Line
	6450 1400 6450 1350
Wire Wire Line
	5800 1900 5800 4000
Wire Wire Line
	5900 1900 5900 3800
Wire Wire Line
	6000 1900 6000 3900
Wire Wire Line
	6100 1900 6100 4200
Wire Wire Line
	6200 1900 6200 4300
Wire Wire Line
	6300 1900 6300 4100
Wire Wire Line
	5450 1900 5450 2100
Wire Wire Line
	5200 1500 5200 1650
Wire Wire Line
	6450 1500 6450 1650
Wire Wire Line
	3350 2200 5250 2200
Wire Wire Line
	4150 5350 5250 5350
Wire Wire Line
	1150 1700 1950 1700
Connection ~ 1950 1700
$Comp
L Switch:SW_DIP_x01 SW1
U 1 1 5CE90EEF
P 1600 1500
F 0 "SW1" H 1600 1767 50  0000 C CNN
F 1 "SW_FOKAPCS" H 1600 1676 50  0000 C CNN
F 2 "" H 1600 1500 50  0001 C CNN
F 3 "~" H 1600 1500 50  0001 C CNN
	1    1600 1500
	1    0    0    -1  
$EndComp
Wire Wire Line
	1900 1500 2050 1500
Connection ~ 2050 1500
$EndSCHEMATC
