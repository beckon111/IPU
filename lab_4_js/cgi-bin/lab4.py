#!/usr/bin/env python3
#  coding=utf-8
import cgi
from ruamel.yaml import YAML
import os
import json

form = cgi.FieldStorage()
if 'device' in form:
    os.popen("diskutil unmount /dev/"+form['device'].value)
    exit()
str = os.popen("system_profiler SPUSBDataType").read()
str = str.replace("\n\n", "\n")
str = str[0:str.index("Host Controller Driver:")] + str[str.rindex("Built-In: Yes") + len("Built-In: Yes"):len(str)]
str = str.replace("\n\n", "\n")

yaml = YAML()
code = yaml.load(str)

print ("Content-Type: application/json")
print()
print (json.dumps(code, sort_keys=True, indent=2))