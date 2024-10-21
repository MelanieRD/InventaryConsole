using System;
using System.IO;

class Program
{


    
    static void Main(string[] args)
    {
        Intro();

    }


    static void Intro() {

        Console.WriteLine("Estas en tu inventario de jugador");
        Console.WriteLine($" \nMenu de opciones: \n\n" +
            $"1. Ver Objetos inventario \n" +
            $"2. Agregar Objeto al inventario \n" +
            $"3. Eliminar objeto del inventario \n" +
            $"4. Salir? \n");

        Console.Write("Ingresa la opcion del menu al cual acceder: ");
        int option = Int32.Parse(Console.ReadLine());
        menu(option);

    }

    static void WriteObjInventory(string inventoryFile, string obj)
    {
        try
        {
            // agregando mis objs
            File.AppendAllText(inventoryFile, obj + Environment.NewLine);
            Console.WriteLine("\n Objeto guardado en el Inventario <3.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al guardar en el inventario: " + ex.Message);
        }
    }


    static void ShowInventory(string inventaryFile)
    {
        try
        {
            // Leer el contenido del archivo
            string AllMyContent = File.ReadAllText(inventaryFile);
            Console.WriteLine("Contenido del inventario:");
            Console.WriteLine(AllMyContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al mostrar objetos del inventario: " + ex.Message);
        }
    }

    static void DeleteObjInventory( string inventaryFile, string objToDelete) {
        try
        {
     
            string[] objectsInventory = File.ReadAllLines(inventaryFile);
           
            using (StreamWriter writer = new StreamWriter(inventaryFile))
            {
                foreach (string objectInvebtory in objectsInventory)
                {
                    // escribir obj que no coincidan con el objeto a eliminar obvio
                    if (!objectInvebtory.Equals(objToDelete, StringComparison.OrdinalIgnoreCase))
                    {
                        writer.WriteLine(objectInvebtory);
                    }
                }
            }
            Console.WriteLine($"Objeto '{objToDelete}' eliminado del inventario.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al eliminar del inventario: " + ex.Message);
        }

    }

    

    static void menu(int option) {

        string inventaryFile = "Inventary.txt";

        switch (option) {
           
            case 1:
                Console.WriteLine("\n Opcion 1 seleccionada \n");
                ShowInventory(inventaryFile);
                repeatMenu();
                break;
               
            case 2:

                Console.Write(" \n Ingresa el nombre del objeto que deseas guardar en el inventario:");
                string newObject = Console.ReadLine();
                WriteObjInventory(inventaryFile, newObject);
                repeatMenu();

                break;


                case 3:
                Console.Write(" \n Ingresa el nombre del objeto a eliminar del inventario: ");
                string objtoDelete = Console.ReadLine();
                DeleteObjInventory(inventaryFile, objtoDelete);
                repeatMenu();
                break;
             case 4:
                Console.WriteLine("Adios!");
                break;

        
        
        }
    
    }

    static void repeatMenu() {

        Console.Write("\n Desea salir de la aplicacion s/n ? \n");

        string salir = Console.ReadLine();

        if (salir == "n")
        {

            Console.Clear();

            Console.WriteLine("\n Por favor introduzca otra accion a realizar\n");
            Intro();
        }


    }


}
