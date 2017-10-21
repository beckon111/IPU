#!/bin/bash
lspci -vmm | grep -E "(^Vendor|^Device)"
