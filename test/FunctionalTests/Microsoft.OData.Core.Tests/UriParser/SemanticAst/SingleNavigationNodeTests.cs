﻿//---------------------------------------------------------------------
// <copyright file="SingleNavigationNodeTests.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

using Microsoft.OData.UriParser;
using Microsoft.OData.Edm;
using Xunit;

namespace Microsoft.OData.Tests.UriParser.SemanticAst
{
    public class SingleNavigationNodeTests
    {
        [Fact]
        public void SourceIsSet()
        {
            var source = FakeSingleEntityNode.CreateFakeSingleEntityNodeForPerson();
            var node = new SingleNavigationNode(source, HardCodedTestModel.GetPersonMyDogNavProp(), new EdmPathExpression("MyDog"));

            Assert.Same(node.Source, source);
        }

        [Fact]
        public void TypeReferenceIsExactlyFromProperty()
        {
            var source = FakeSingleEntityNode.CreateFakeSingleEntityNodeForPerson();
            var node = new SingleNavigationNode(source, HardCodedTestModel.GetPersonMyDogNavProp(), new EdmPathExpression("MyDog"));

            Assert.Same(node.TypeReference, HardCodedTestModel.GetPersonMyDogNavProp().Type);
        }

        [Fact]
        public void EntityTypeIsSameAsType()
        {
            var source = FakeSingleEntityNode.CreateFakeSingleEntityNodeForPerson();
            var node = new SingleNavigationNode(source, HardCodedTestModel.GetPersonMyDogNavProp(), new EdmPathExpression("MyDog"));

            Assert.Same(node.EntityTypeReference, node.TypeReference);
        }

        [Fact]
        public void EntitySetIsCalculatedCorrectly()
        {
            var source = FakeSingleEntityNode.CreateFakeSingleEntityNodeForPerson();
            var node = new SingleNavigationNode(source, HardCodedTestModel.GetPersonMyDogNavProp(), new EdmPathExpression("MyDog"));

            Assert.Same(node.NavigationSource, HardCodedTestModel.GetDogsSet());
        }

        [Fact]
        public void SingleNavigationNodeHandlesNullEntitySetOnParentNode()
        {
            var source = new FakeSingleEntityNode(HardCodedTestModel.GetPersonTypeReference(), null);
            var node = new SingleNavigationNode(source, HardCodedTestModel.GetPersonMyDogNavProp(), new EdmPathExpression("MyDog"));

            Assert.Null(node.NavigationSource);
        }

        [Fact]
        public void SingleNavigationNodeHandlesNullSourceSetParameter()
        {
            var node = new SingleNavigationNode((IEdmEntitySet)null, HardCodedTestModel.GetPersonMyDogNavProp(), new EdmPathExpression("MyDog"));
            Assert.Null(node.NavigationSource);
        }

        [Fact]
        public void KindIsEntitySet()
        {
            var source = FakeSingleEntityNode.CreateFakeSingleEntityNodeForPerson();
            var node = new SingleNavigationNode(source, HardCodedTestModel.GetPersonMyDogNavProp(), new EdmPathExpression("MyDog"));

            Assert.Equal(InternalQueryNodeKind.SingleNavigationNode, node.InternalKind);
        }
    }
}
