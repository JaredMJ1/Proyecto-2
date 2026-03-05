using DataAccess.DAO;
using Microsoft.Data.SqlClient;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        int option = -1;

        while (option != 0)
        {
            Console.Clear();

            Console.WriteLine("====== MENU ======");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Update User");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. Create Product");
            Console.WriteLine("5. Update Product");
            Console.WriteLine("6. Delete Product");
            Console.WriteLine("0. Exit");
            Console.WriteLine("==================");

            Console.Write("Option: ");

            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid option.");
                Pause();
                continue;
            }

            switch (option)
            {
                case 1: CreateUser(); break;
                case 2: UpdateUser(); break;
                case 3: DeleteUser(); break;
                case 4: CreateProduct(); break;
                case 5: UpdateProduct(); break;
                case 6: DeleteProduct(); break;
                case 0:
                    Console.WriteLine("Bye 👋");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            if (option != 0)
                Pause();
        }
    }

    static void CreateUser()
    {
        var op = new SQLOPERATION { ProcedureName = "dbo.usp_InsertUsuario" };

        Console.Write("Name: ");
        // Cambiamos @Name por @P_NAME
        op.AddStringParam("@P_NAME", Console.ReadLine());

        Console.Write("Lastname: ");
        // Cambiamos @Lastname por @P_LAST_NAME
        op.AddStringParam("@P_LAST_NAME", Console.ReadLine());

        Console.Write("Email: ");
        // Cambiamos @Email por @P_EMAIL
        op.AddStringParam("@P_EMAIL", Console.ReadLine());

        Console.Write("Phone: ");
        // Cambiamos @Phone por @P_PHONE
        op.AddStringParam("@P_PHONE", Console.ReadLine());

        Console.Write("Password: ");
        // Cambiamos @PasswordHash por @P_PASSWORD
        op.AddStringParam("@P_PASSWORD", Console.ReadLine());

        Console.Write("Birthday (yyyy-mm-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime birthday))
            op.AddDateTimeParam("@P_BIRTH_DATE", birthday); // Cambiamos @Birthday por @P_BIRTH_DATE
        else
        {
            Console.WriteLine("Invalid date format.");
            return;
        }

        // Nota: Si tu SP no pide @P_STATUS, quita esta línea para evitar el error de "too many arguments"
        // op.AddStringParam("@P_STATUS", "ACTIVE"); 

        Execute(op, "User created");
    }

    static void UpdateUser()
{
    var op = new SQLOPERATION { ProcedureName = "dbo.usp_UpdateUsuario" };

    Console.Write("User Id: ");
    if (!int.TryParse(Console.ReadLine(), out int id)) { return; }

    op.AddIntParam("@P_ID", id); // Asegúrate que en SQL sea @P_ID
    Console.Write("Name: ");
    op.AddStringParam("@P_NAME", Console.ReadLine());
    Console.Write("Lastname: ");
    op.AddStringParam("@P_LAST_NAME", Console.ReadLine());
    Console.Write("Email: ");
    op.AddStringParam("@P_EMAIL", Console.ReadLine());
    Console.Write("Phone: ");
    op.AddStringParam("@P_PHONE", Console.ReadLine());

    Execute(op, "User updated");
}

    static void DeleteUser()
    {
        var op = new SQLOPERATION { ProcedureName = "dbo.usp_DeleteUsuario" };

        Console.Write("User Id: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid Id.");
            return;
        }

        op.AddIntParam("@Id", id);

        Execute(op, "User deleted");
    }

    static void CreateProduct()
    {
        var op = new SQLOPERATION { ProcedureName = "dbo.usp_InsertProduct" };

        Console.Write("Name: ");
        op.AddStringParam("@Name", Console.ReadLine());

        Console.Write("Description: ");
        op.AddStringParam("@Description", Console.ReadLine());

        Console.Write("Category: ");
        op.AddStringParam("@Category", Console.ReadLine());

        Console.Write("Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }

        op.AddIntParam("@Quantity", quantity);

        Console.Write("Price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.WriteLine("Invalid price.");
            return;
        }

        op.AddDecimalParam("@Price", price);

        op.AddStringParam("@Status", "ACTIVE");

        Execute(op, "Product created");
    }

    static void UpdateProduct()
    {
        var op = new SQLOPERATION { ProcedureName = "dbo.usp_UpdateProduct" };

        Console.Write("Product Id: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid Id.");
            return;
        }

        op.AddIntParam("@Id", id);

        Console.Write("Name: ");
        op.AddStringParam("@Name", Console.ReadLine());

        Console.Write("Description: ");
        op.AddStringParam("@Description", Console.ReadLine());

        Console.Write("Category: ");
        op.AddStringParam("@Category", Console.ReadLine());

        Console.Write("Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }

        op.AddIntParam("@Quantity", quantity);

        Console.Write("Price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.WriteLine("Invalid price.");
            return;
        }

        op.AddDecimalParam("@Price", price);

        op.AddStringParam("@Status", "ACTIVE");

        Execute(op, "Product updated");
    }

    static void DeleteProduct()
    {
        var op = new SQLOPERATION { ProcedureName = "dbo.usp_DeleteProduct" };

        Console.Write("Product Id: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid Id.");
            return;
        }

        op.AddIntParam("@Id", id);

        Execute(op, "Product deleted");
    }

    static void Execute(SQLOPERATION operation, string successMessage)
    {
        try
        {
            SQLDAO.GetInstance().ExecuteProcedure(operation);
            Console.WriteLine(successMessage + " successfully ✅");
        }
        catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
        {
            Console.WriteLine("❌ Duplicate value (possibly Email already exists).");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Operation failed.");
            Console.WriteLine(ex.Message);
        }
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
