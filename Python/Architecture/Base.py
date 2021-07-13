from typing import Dict, List


class Base:
    __base_values: Dict[str, int]
    __base_characters: Dict[int, str]
    __number_of_symbols: int


    def __init__(self, dictionary: Dict[str, int]) -> Base:
        self.__base_values = dictionary
        self.__base_characters = {}
        self.__number_of_symbols = len(self.__base_values)
        for (symbol, num) in dictionary:
            self.__base_characters[num] = symbol

    def get_base_values_dic(self) -> Dict[str, int]:
        return self.__base_values

    def get_base_characters_dic(self) -> Dict[int, str]:
        return self.__base_characters

    def get_number_of_symbols(self) -> int:
        return self.__number_of_symbols

    @property
    def get_base_values(self) -> List[int]:
        base_values: List[int] = []
        for (symbol, num) in self.__base_values:
            base_values.append(num)
        return base_values

    @property
    def get_base_symbol(self) -> List[str]:
        base_symbol: List[str] = []
        for (symbol, num) in self.__base_values:
            base_symbol.append(symbol)
        return base_symbol

    @property
    def number_of_symbols(self) -> int:
        return self.__number_of_symbols