using System;

public static class SerialDate {
    // Função que não existe no SerialDate original que foi adicionada posteriormente.
    // Esse é apenas um EXEMPLO, a função SerialDate não existe em C# somente em JAVA.
    // Essa função foi criada para exemplificar a refatoração.
    public static int GetQuarterFromMonth (int month) {
        if (month < 1 || month > 12)
            throw new ArgumentException("Mes invalido");

        return (month - 1) / 3 + 1;
    }
}
