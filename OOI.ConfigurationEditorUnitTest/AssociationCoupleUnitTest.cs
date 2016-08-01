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

using System;
using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
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
      AssociationConfigurationWrapper _wrapper = new AssociationConfigurationWrapper();
      AssociationCoupler _couple = new AssociationCoupler(null, (x, y) => _associated = x, "Title", _wrapper);
      Assert.IsFalse(_couple.Associated);
      Assert.AreEqual<string>("Title", _couple.Title);
      Assert.IsNotNull( _couple.AssociationWrapper);
      Assert.AreSame(_wrapper, _couple.AssociationWrapper);
    }

    [TestMethod]
    public void ApplyChanges()
    {
      bool _associated = false;
      AssociationConfigurationWrapper _wrapper = new AssociationConfigurationWrapper();
      AssociationCoupler _couple = new AssociationCoupler(_wrapper, (x, y) => _associated = x, "Title", new AssociationConfigurationWrapper());
      Assert.IsTrue(_couple.Associated);
      _couple.ApplyChanges(true);
      Assert.IsTrue(_couple.Associated);
      Assert.IsTrue(_associated);
    }
    private class AssociationConfigurationWrapper : IAssociationConfigurationWrapper
    {
      public string AssociationName
      {
        get
        {
          throw new NotImplementedException();
        }

        set
        {
          throw new NotImplementedException();
        }
      }
      public ushort DataSetWriterId
      {
        get
        {
          throw new NotImplementedException();
        }

        set
        {
          throw new NotImplementedException();
        }
      }
      public Guid PublisherId
      {
        get
        {
          throw new NotImplementedException();
        }

        set
        {
          throw new NotImplementedException();
        }
      }
    }

  }
}
