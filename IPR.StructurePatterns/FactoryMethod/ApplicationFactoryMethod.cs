﻿namespace IPR.StructurePatterns.FactoryMethod;

public class ApplicationFactoryMethod
{
    private ProductCreator _creator;

    public void Init(string env)
    {
        if(env == "Туалет")
        {
            _creator = new PovidloCreator();
        }
        else
        {
            _creator = new AppleCreator();
        }

        _creator.Say();
    }
}


/*
 
Фабричный метод — это порождающий паттерн проектирования, 
                  который определяет общий интерфейс для создания объектов в суперклассе, 
                  позволяя подклассам изменять тип создаваемых объектов.

 + Избавляет класс от привязки к конкретным классам продуктов.
 + Выделяет код производства продуктов в одно место, упрощая поддержку кода.
 + Упрощает добавление новых продуктов в программу.
 + Реализует принцип открытости/закрытости.
 
 - Может привести к созданию больших параллельных иерархий классов, так как для каждого класса 
  продукта надо создать свой подкласс создателя.
 
 */