#!/bin/bash
sudo hdparm -I /dev/sda | grep Number
sudo hdparm -I /dev/sda | grep Firmware
sudo hdparm -I /dev/sda | grep PIO
sudo hdparm -I /dev/sda | grep DMA
sudo hdparm -I /dev/sda | grep Supported
df | awk '{size+=$2; used+=$3; avail+=$4} END {print "Size: " size "\n" "Used " used "\n" "Avail " avail}'
