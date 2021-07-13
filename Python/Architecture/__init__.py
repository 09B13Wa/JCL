# -*- coding: utf-8 -*-

import asyncio
import time


async def bis(age: int) -> int:
    time.sleep(50)
    return age


def example(name: str, age: int) -> None:
    time.sleep(100)
    age = await bis(age)
    print("Salut a " + name + " qui à " + str(age))


if __name__ == 'main':
    example("Jascha", 19)
