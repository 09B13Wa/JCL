# -*- coding: utf-8 -*-

import asyncio
import time
from threading import Thread

boucle_allume: bool = True

def example(limite, enieme):
    global boucle
    boucle.rai
    i = 0
    while i < limite:
        print(str(i) + " iteration de la boucle n°" + enieme)
        i += 1


boucle = Thread(target=example, args=[20, "1"])
boucle2 = Thread(target=example, args=[30, "2"])
boucle.start()
boucle2.start()
