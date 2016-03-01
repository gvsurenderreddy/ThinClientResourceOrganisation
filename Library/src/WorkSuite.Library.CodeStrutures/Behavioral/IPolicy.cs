namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral {

    public interface IPolicy<C> {

         bool decide_for ( C context );

    }

}