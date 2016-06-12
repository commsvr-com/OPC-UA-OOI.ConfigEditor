//_______________________________________________________________
//  Title   : AssociationCoupleUnitTest
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.CommServer.UA.OOI.ConfigurationEditor.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{

  [TestClass]
  public class AssociationCoupleUnitTest
  {

    [TestMethod]
    public void AfterCreationTest()
    {
      bool _associated = false;
      AssociationCoupler _couple = new AssociationCoupler(() => _associated, x => _associated = x, "Title");
      Assert.IsFalse(_couple.Associated);
      _couple.Associated = true;
      Assert.IsTrue(_associated);
      Assert.IsTrue(_couple.Associated);
      Assert.AreEqual<string>("Title", _couple.Title);
    }

    [TestMethod]
    public void RevertTest()
    {
      bool _associated = false;
      AssociationCoupler _couple = new AssociationCoupler(() => _associated, x => _associated = x, "");
      Assert.IsFalse(_couple.Associated);
      _couple.Associated = true;
      Assert.IsTrue(_associated);
      _couple.Revert();
      Assert.IsFalse(_couple.Associated);
      Assert.IsFalse(_associated);
    }

  }
}
