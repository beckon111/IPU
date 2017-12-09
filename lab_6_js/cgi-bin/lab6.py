#!/usr/bin/env python3
#  coding=utf-8
import cgi
from ruamel.yaml import YAML
from ruamel.yaml.constructor import SafeConstructor
import os
import json

form = cgi.FieldStorage()
if 'network' in form:
    os.popen("networksetup -setairportnetwork en0 "+form['network'].value+" " + form['password'])
    exit()
str = os.popen("system_profiler SPAirPortDataType").read()
str = str.replace("\n\n", "\n")
str = str.replace("\n\n", "\n")

def construct_yaml_map(self, node):
    # test if there are duplicate node keys
    data = []
    yield data
    for key_node, value_node in node.value:
        key = self.construct_object(key_node, deep=True)
        val = self.construct_object(value_node, deep=True)
        data.append((key, val))


SafeConstructor.add_constructor(u'tag:yaml.org,2002:map', construct_yaml_map)

yaml = YAML(typ='safe')
code = yaml.load(str)

print ("Content-Type: application/json")
print()
print (json.dumps(code, sort_keys=True, indent=2))