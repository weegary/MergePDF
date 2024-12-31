using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

// Define the input directory and output file path
string inputDirectory = @"input"; // Folder containing PDF files
string outputFilePath = @"output.pdf"; // Output merged PDF file

// Create a new PDF document
using (PdfDocument outputDocument = new PdfDocument())
{
    // Get all PDF files from the input directory
    string[] pdfFiles = Directory.GetFiles(inputDirectory, "*.pdf");

    // Merge each PDF file into the final document
    foreach (string pdfFile in pdfFiles)
    {
        // Open the file
        PdfDocument inputDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);

        // Add all pages to the output document
        for (int i = 0; i < inputDocument.PageCount; i++)
        {
            outputDocument.AddPage(inputDocument.Pages[i]);
        }
    }

    // Save the merged document
    outputDocument.Save(outputFilePath);
}

Console.WriteLine("所有PDF檔案已成功合并於" + outputFilePath);
Console.WriteLine("此程式由Gary工程師與小賴工程師聯合開發。祝新年快樂。");
