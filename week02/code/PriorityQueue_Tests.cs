using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{

    [TestMethod]
    // Scenario: Two itmes are added to the priority queue to verify that the Enqueue method add item to the back of the queue.
    // Expected Result: PriorityQueue.Count is supposed to equal to 2 because i added two item to the queue.
    // Defect(s) Found: No default found
    public void TestPriorityQueue_0()
    {
        var priorityQueue = new PriorityQueue();
        var item1 = new PriorityItem("item1", 2);
        var item2 = new PriorityItem("item2", 2);

        priorityQueue.Enqueue(item1.Value, item1.Priority);
        priorityQueue.Enqueue(item2.Value, item2.Priority);

        var expectedCount = 2;
        Assert.AreEqual(expectedCount, priorityQueue.QueueCount);
    }

    [TestMethod]
    // Scenario: Create a queue with different value string and different priority numbers to make sure that the returned value from the Dequeue method is always the one with the highest priority.
    // Expected Result: The value return from dequest should be the string "highest"
    // Defect(s) Found: No defects found
    public void TestPriorityQueue_1()
    {
        var highest = new PriorityItem("highest", 6);
        var middle = new PriorityItem("middle", 3);
        var lowest = new PriorityItem("lowest", 1);

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(highest.Value, highest.Priority);
        priorityQueue.Enqueue(middle.Value, middle.Priority);
        priorityQueue.Enqueue(lowest.Value, lowest.Priority);

        var expectedValue = "highest";

        var testDequeue = priorityQueue.Dequeue();
        Assert.AreEqual(expectedValue, testDequeue);
    }

    [TestMethod]
    // Scenario: There are two items with the same highest priority. The highest item that was insert inside queue first should be the first to be the one returned here.
    // Expected Result: "highest1" should be the value returned because it is the closest to the Front, qhich mean it was added to the queue before the other with highest priority "highest2"
    // Defect(s) Found: The Dequeue function returned the last item it loop throught that has the highest priority. | The loop skipped the lasy item in the queue.
    // This was fixed
    public void TestPriorityQueue_2()
    {
        var highest1 = new PriorityItem("highest1", 10);
        var high = new PriorityItem("high", 7);
        var medium = new PriorityItem("medium", 5);
        var highest2 = new PriorityItem("highest2", 10);
        var low = new PriorityItem("low", 3);
        var lowest = new PriorityItem("lowest", 1);

        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(high.Value, high.Priority);
        priorityQueue.Enqueue(highest1.Value, highest1.Priority);
        priorityQueue.Enqueue(lowest.Value, lowest.Priority);
        priorityQueue.Enqueue(medium.Value, medium.Priority);
        priorityQueue.Enqueue(highest2.Value, highest2.Priority);
        priorityQueue.Enqueue(low.Value, low.Priority);

        var expectedValue = "highest1";

        var testDequeue = priorityQueue.Dequeue();

        Assert.AreEqual(expectedValue, testDequeue);

    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: No default found
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");

        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message)
            );
        }
    }


} 