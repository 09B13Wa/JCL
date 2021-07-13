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


import threading


class StoppableThread(threading.Thread):
    """Thread class with a stop() method. The thread itself has to check
    regularly for the stopped() condition."""

    def __init__(self,  *args, **kwargs):
        super(StoppableThread, self).__init__(*args, **kwargs)
        self._stop_event = threading.Event()

    def stop(self):
        self._stop_event.set()

    def stopped(self):
        return self._stop_event.is_set()


boucle = Thread(target=example, args=[20, "1"])
boucle2 = Thread(target=example, args=[30, "2"])
boucle.start()
boucle2.start()
