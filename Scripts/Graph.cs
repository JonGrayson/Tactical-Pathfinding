using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    List<Connection> mConnections;

    public List<Connection> getConnections(Node fromNode)
    {
        List<Connection> connections = new List<Connection>();
        foreach (Connection c in mConnections)
        {
            if(c.getFromNode() == fromNode)
            {
                connections.Add(c);
            }
        }

        return connections;
    }

    public void Build(bool IfCostEffective)
    {
        mConnections = new List<Connection>();

        Node[] nodes = GameObject.FindObjectsOfType<Node>();

        if (IfCostEffective)
        {
            foreach (Node fromNode in nodes)
            {
                foreach (Node toNode in fromNode.ConnectsTo)
                {
                    float cost = (toNode.transform.position - fromNode.transform.position).magnitude;

                    if(fromNode.gameObject.name.Contains("Cheaper") && toNode.gameObject.name.Contains("Cheaper"))
                    {
                        cost = 1.0f;
                    }

                    else
                    {
                        cost = (toNode.transform.position - fromNode.transform.position).magnitude;
                    }

                    Connection c = new Connection(cost, fromNode, toNode);
                    mConnections.Add(c);
                }
            }
        }

        else
        {
            foreach (Node fromNode in nodes)
            {
                foreach (Node toNode in fromNode.ConnectsTo)
                {
                    float cost = (toNode.transform.position - fromNode.transform.position).magnitude;
                    Connection c = new Connection(cost, fromNode, toNode);
                    mConnections.Add(c);
                }
            }
        }
    }
}

public class Connection
{
    float cost;
    Node fromNode;
    Node toNode;

    public Connection(float cost, Node fromNode, Node toNode)
    {
        this.cost = cost;
        this.fromNode = fromNode;
        this.toNode = toNode;
    }

    public float getCost()
    {
        return cost;
    }

    public Node getFromNode()
    {
        return fromNode;
    }

    public Node getToNode()
    {
        return toNode;
    }
}
