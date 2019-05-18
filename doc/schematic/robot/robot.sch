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
L MCU_Module:Arduino_UNO_R3 A?
U 1 1 5CBB77F7
P 7300 3600
F 0 "A?" H 7300 4781 50  0000 C CNN
F 1 "Arduino_UNO_R3" H 7300 4690 50  0000 C CNN
F 2 "Module:Arduino_UNO_R3" H 7450 2550 50  0001 L CNN
F 3 "https://www.arduino.cc/en/Main/arduinoBoardUno" H 7100 4650 50  0001 C CNN
	1    7300 3600
	1    0    0    -1  
$EndComp
$Comp
L robot:BME280breakout U?
U 1 1 5CBD2A13
P 9350 2150
F 0 "U?" H 9408 2275 50  0000 C CNN
F 1 "BME280breakout" H 9408 2184 50  0000 C CNN
F 2 "" H 9350 2150 50  0001 C CNN
F 3 "" H 9350 2150 50  0001 C CNN
	1    9350 2150
	1    0    0    -1  
$EndComp
$Comp
L robot:LSM303C_breakout U?
U 1 1 5CBD3076
P 9550 3500
F 0 "U?" H 9525 3625 50  0000 C CNN
F 1 "LSM303C_breakout" H 9525 3534 50  0000 C CNN
F 2 "" H 9550 3500 50  0001 C CNN
F 3 "" H 9550 3500 50  0001 C CNN
	1    9550 3500
	1    0    0    -1  
$EndComp
$Comp
L robot:DC-DC_buck U?
U 1 1 5CBD361D
P 2450 1600
F 0 "U?" H 2400 1925 50  0000 C CNN
F 1 "DC-DC_buck" H 2400 1834 50  0000 C CNN
F 2 "" H 2350 1800 50  0001 C CNN
F 3 "" H 2350 1800 50  0001 C CNN
	1    2450 1600
	1    0    0    -1  
$EndComp
$Comp
L robot:RPi_3b+ U?
U 1 1 5CBD38D7
P 2700 2500
F 0 "U?" H 2775 2965 50  0000 C CNN
F 1 "RPi_3b+" H 2775 2874 50  0000 C CNN
F 2 "" H 2750 1450 50  0001 C CNN
F 3 "" H 2750 1450 50  0001 C CNN
	1    2700 2500
	1    0    0    -1  
$EndComp
Text GLabel 3550 2350 2    50   Input ~ 0
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
P 650 1500
F 0 "#PWR?" H 650 1350 50  0001 C CNN
F 1 "+BATT" H 665 1673 50  0000 C CNN
F 2 "" H 650 1500 50  0001 C CNN
F 3 "" H 650 1500 50  0001 C CNN
	1    650  1500
	1    0    0    -1  
$EndComp
$Comp
L power:-BATT #PWR?
U 1 1 5CBE5999
P 950 1700
F 0 "#PWR?" H 950 1550 50  0001 C CNN
F 1 "-BATT" H 950 1850 50  0000 C CNN
F 2 "" H 950 1700 50  0001 C CNN
F 3 "" H 950 1700 50  0001 C CNN
	1    950  1700
	1    0    0    -1  
$EndComp
$Comp
L robot:L298N_module U?
U 1 1 5CBE7604
P 5600 1200
F 0 "U?" H 5825 1315 50  0000 C CNN
F 1 "L298N_module" H 5825 1224 50  0000 C CNN
F 2 "" H 5600 1200 50  0001 C CNN
F 3 "" H 5600 1200 50  0001 C CNN
	1    5600 1200
	1    0    0    -1  
$EndComp
$Comp
L Motor:Motor_DC M?
U 1 1 5CBE8A46
P 4650 1350
F 0 "M?" H 4808 1346 50  0000 L CNN
F 1 "Motor_DC" H 4808 1255 50  0000 L CNN
F 2 "" H 4650 1260 50  0001 C CNN
F 3 "~" H 4650 1260 50  0001 C CNN
	1    4650 1350
	1    0    0    -1  
$EndComp
$Comp
L Motor:Motor_DC M?
U 1 1 5CBE91A7
P 7000 1450
F 0 "M?" H 7158 1446 50  0000 L CNN
F 1 "Motor_DC" H 7158 1355 50  0000 L CNN
F 2 "" H 7000 1360 50  0001 C CNN
F 3 "~" H 7000 1360 50  0001 C CNN
	1    7000 1450
	1    0    0    -1  
$EndComp
$Comp
L Device:C C?
U 1 1 5CBE94B6
P 4250 1400
F 0 "C?" H 4365 1446 50  0000 L CNN
F 1 "C" H 4365 1355 50  0000 L CNN
F 2 "" H 4288 1250 50  0001 C CNN
F 3 "~" H 4250 1400 50  0001 C CNN
	1    4250 1400
	1    0    0    -1  
$EndComp
$Comp
L Device:C C?
U 1 1 5CBE9D6C
P 6600 1500
F 0 "C?" H 6715 1546 50  0000 L CNN
F 1 "C" H 6715 1455 50  0000 L CNN
F 2 "" H 6638 1350 50  0001 C CNN
F 3 "~" H 6600 1500 50  0001 C CNN
	1    6600 1500
	1    0    0    -1  
$EndComp
Wire Wire Line
	2750 1700 2750 1850
Wire Wire Line
	2750 1850 1850 1850
Wire Wire Line
	1850 1850 1850 2550
Wire Wire Line
	1850 2550 2000 2550
Wire Wire Line
	2750 1500 2900 1500
Wire Wire Line
	2900 1500 2900 1950
Wire Wire Line
	2900 1950 1700 1950
Wire Wire Line
	1700 5150 2350 5150
Wire Wire Line
	2350 5150 2350 5000
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
	6450 1400 6450 1350
Wire Wire Line
	6450 1350 6600 1350
Wire Wire Line
	6600 1350 6600 1250
Wire Wire Line
	6600 1250 7000 1250
Connection ~ 6600 1350
Wire Wire Line
	6450 1500 6450 1550
Wire Wire Line
	6450 1650 6600 1650
Wire Wire Line
	6600 1650 6600 1750
Wire Wire Line
	6600 1750 7000 1750
Connection ~ 6600 1650
Wire Wire Line
	5200 1400 5200 1150
Wire Wire Line
	5200 1150 4650 1150
Wire Wire Line
	4650 1150 4250 1150
Wire Wire Line
	4250 1150 4250 1250
Connection ~ 4650 1150
Wire Wire Line
	5200 1500 5200 1550
Wire Wire Line
	5200 1650 4650 1650
Wire Wire Line
	4650 1650 4250 1650
Wire Wire Line
	4250 1650 4250 1550
Connection ~ 4650 1650
Wire Wire Line
	1700 1950 1700 5150
Wire Wire Line
	650  1500 1650 1500
Wire Wire Line
	950  1700 1850 1700
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
	5800 4000 5800 1950
Wire Wire Line
	6800 4100 6300 4100
Wire Wire Line
	6300 4100 6300 1950
Wire Wire Line
	6800 3800 5900 3800
Wire Wire Line
	5900 3800 5900 1950
Wire Wire Line
	6800 3900 6000 3900
Wire Wire Line
	6000 3900 6000 1950
Wire Wire Line
	6800 4200 6100 4200
Wire Wire Line
	6100 4200 6100 1950
Wire Wire Line
	6800 4300 6200 4300
Wire Wire Line
	6200 4300 6200 1950
Wire Wire Line
	1650 1500 1650 1050
Wire Wire Line
	1650 1050 3700 1050
Wire Wire Line
	3700 1050 3700 1950
Wire Wire Line
	3700 1950 5350 1950
Wire Wire Line
	5350 1950 5350 1900
Connection ~ 1650 1500
Wire Wire Line
	1650 1500 2050 1500
Wire Wire Line
	1850 1700 1850 1200
Wire Wire Line
	1850 1200 3500 1200
Wire Wire Line
	3500 1200 3500 2100
Wire Wire Line
	3500 2100 5450 2100
Wire Wire Line
	5450 2100 5450 1950
Connection ~ 1850 1700
Wire Wire Line
	1850 1700 2050 1700
$Comp
L Device:LED D?
U 1 1 5CCB8547
P 1250 3850
F 0 "D?" H 1243 4066 50  0000 C CNN
F 1 "Ready_LED" H 1243 3975 50  0000 C CNN
F 2 "" H 1250 3850 50  0001 C CNN
F 3 "~" H 1250 3850 50  0001 C CNN
	1    1250 3850
	1    0    0    -1  
$EndComp
$Comp
L Device:LED D?
U 1 1 5CCBBC55
P 1250 4200
F 0 "D?" H 1243 4416 50  0000 C CNN
F 1 "Running_LED" H 1243 4325 50  0000 C CNN
F 2 "" H 1250 4200 50  0001 C CNN
F 3 "~" H 1250 4200 50  0001 C CNN
	1    1250 4200
	1    0    0    -1  
$EndComp
Wire Wire Line
	1400 3850 2000 3850
Wire Wire Line
	2000 3950 1600 3950
Wire Wire Line
	1600 3950 1600 4200
Wire Wire Line
	1600 4200 1400 4200
$Comp
L power:GND #PWR?
U 1 1 5CCC0411
P 850 4200
F 0 "#PWR?" H 850 3950 50  0001 C CNN
F 1 "GND" H 855 4027 50  0000 C CNN
F 2 "" H 850 4200 50  0001 C CNN
F 3 "" H 850 4200 50  0001 C CNN
	1    850  4200
	1    0    0    -1  
$EndComp
Wire Wire Line
	1100 3850 850  3850
Wire Wire Line
	850  3850 850  4200
Wire Wire Line
	1100 4200 850  4200
Connection ~ 850  4200
Connection ~ 5200 1550
Wire Wire Line
	5200 1550 5200 1650
Connection ~ 5350 1950
Connection ~ 5450 1950
Wire Wire Line
	5450 1950 5450 1900
Connection ~ 5800 1950
Wire Wire Line
	5800 1950 5800 1900
Connection ~ 5900 1950
Wire Wire Line
	5900 1950 5900 1900
Connection ~ 6000 1950
Wire Wire Line
	6000 1950 6000 1900
Connection ~ 6100 1950
Wire Wire Line
	6100 1950 6100 1900
Connection ~ 6200 1950
Wire Wire Line
	6200 1950 6200 1900
Connection ~ 6300 1950
Wire Wire Line
	6300 1950 6300 1900
Connection ~ 6450 1550
Wire Wire Line
	6450 1550 6450 1650
$Comp
L robot:RPi_cam U?
U 1 1 5CCCFA59
P 3900 2650
F 0 "U?" H 3837 2775 50  0000 C CNN
F 1 "RPi_cam" H 3837 2684 50  0000 C CNN
F 2 "" H 3900 2650 50  0001 C CNN
F 3 "" H 3900 2650 50  0001 C CNN
	1    3900 2650
	1    0    0    -1  
$EndComp
$EndSCHEMATC