namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Services;

public class HtmlDocumentGenerator
{
    private static readonly string[] AllTags =
    [
        "html","head","body","div","span","p","a","img","ul","ol","li",
        "table","tr","td","th","thead","tbody","h1","h2","h3","h4","h5","h6",
        "form","input","button","label","select","option","textarea",
        "header","footer","nav","main","section","article","aside",
        "script","style","link","meta","title","br","hr","strong","em","code",
        "pre","blockquote","figure","figcaption","video","audio","canvas","svg"
    ];

    public void Generate(string dir, int count)
    {
        if (Directory.Exists(dir) && Directory.GetFiles(dir, "*.html").Length >= count)
            return;

        Directory.CreateDirectory(dir);
        var rng = new Random(42);

        for (int i = 0; i < count; i++)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("<!DOCTYPE html><html><head><title>Doc</title></head><body>");
            BuildBody(sb, rng, rng.Next(1, 6));
            sb.AppendLine("</body></html>");
            File.WriteAllText(Path.Combine(dir, $"doc_{i:D5}.html"), sb.ToString());
        }
    }

    private static void BuildBody(System.Text.StringBuilder sb, Random rng, int depth)
    {
        if (depth <= 0) return;
        for (int i = 0; i < rng.Next(1, 8); i++)
        {
            string tag = AllTags[rng.Next(AllTags.Length)];
            sb.Append($"<{tag}>");
            if (rng.Next(3) > 0) BuildBody(sb, rng, depth - 1);
            sb.AppendLine($"</{tag}>");
        }
    }
}
