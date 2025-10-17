using System.Xml;
using System.Xml.Serialization;

[XmlRoot("Aluno")]
public class Aluno
{
    [XmlElement("Nome")]
    public string Nome { get; set; }
    [XmlElement("Curso")]
    public string Curso { get; set; }
}

[XmlRoot("Alunos")]
public class Alunos
{
    [XmlArray("Alunos")]
    [XmlArrayItem("Aluno")]
    public List<Aluno> alunos { get; set; }
}


class Program
{
    static void Main()
    {
        var turma = new Alunos
        {
            alunos = new List<Aluno>
                {
                    new Aluno { Nome = "Maria", Curso = "Sistemas de Informação" },
                    new Aluno { Nome = "João", Curso = "Engenharia de Software" }
                }
        };

        XmlSerializer serializer = new XmlSerializer(typeof(Alunos));
        using (StreamWriter writer = new StreamWriter("turma.xml"))
        {
            serializer.Serialize(writer, turma);
        }

        XmlSerializer serializerin = new XmlSerializer(typeof(Alunos));
        using (StreamReader reader = new StreamReader("turma.xml"))
        {
            Alunos turmades = (Alunos)serializerin.Deserialize(reader);

            foreach (Aluno aluno_list in turmades.alunos)
            {
                Console.WriteLine($"{aluno_list.Nome} - {aluno_list.Curso}");
            }
        }


    }
}
