namespace MTG.Backend
{
    
    public class Zone_Battlefield : Zone
    {
        
        public override bool IsPublic => true;
        public override bool IsShared => true;
        public override bool IsOrdered => false;

    }
    
}
