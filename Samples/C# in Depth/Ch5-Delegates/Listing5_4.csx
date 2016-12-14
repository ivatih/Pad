Derived x = new Derived();
SampleDelegate factory = new SampleDelegate(x.CandidateAction);
factory("test");

delegate void SampleDelegate(string x);

class Base
{
    public void CandidateAction(string x)
    {
        Console.WriteLine("Base.CandidateAction");
    }
}

class Derived : Base
{
    public void CandidateAction(object o)
    {
        Console.WriteLine("Derived.CandidateAction");
    }
}
