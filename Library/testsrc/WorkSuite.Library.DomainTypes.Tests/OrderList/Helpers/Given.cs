using System.Collections.Generic;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Helpers {

    public abstract class Given<W> {

        public Given<W> an_entry_in_the_list_at 
                        ( int position ) {

            list.Add( new TestListElement {
                initial_position = position,
                postion = position,
            } );

            return this;
        }

        public abstract W when ();


        protected TestListElement element_to_insert = new TestListElement(  );
        protected List<TestListElement> list = new List<TestListElement>();

    }

}