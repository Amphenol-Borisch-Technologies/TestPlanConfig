using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

public enum EVENTS { CANCEL, EMERGENCY_STOP, ERROR, FAIL, PASS, UNSET }

public static class TestLib {
    public static Dictionary<EVENTS, Color> EventColors = new Dictionary<EVENTS, Color> {
                { EVENTS.CANCEL, Color.Yellow },
                { EVENTS.EMERGENCY_STOP, Color.Firebrick },
                { EVENTS.ERROR, Color.Aqua },
                { EVENTS.FAIL, Color.Red },
                { EVENTS.PASS, Color.Green },
                { EVENTS.UNSET, Color.Gray }
        };

    public class Operation {
        public readonly String ID;
        public readonly String Revision;
        public readonly String Description;
        public readonly String TestGroupIDs;

        private Operation(String id, String revision, String description, String testGroupIDs) {
            ID = id;
            Revision = revision;
            Description = description;
            TestGroupIDs = testGroupIDs;
        }

        public static Dictionary<String, Operation> Get() {
            TestOperationsSection testOperationsSection = (TestOperationsSection)ConfigurationManager.GetSection(TestOperationsSection.ClassName);
            TestOperations testOperations = testOperationsSection.TestOperations;
            Dictionary<String, Operation> dictionary = new Dictionary<String, Operation>();
            foreach (TestOperation to in testOperations) dictionary.Add(to.ID, new Operation(to.ID, to.Revision, to.Description, to.TestGroupIDs));
            return dictionary;
        }

        public static Operation Get(String TestOperationID) { return Get()[TestOperationID]; }
    }

    public class Group {
        public readonly String ID;
        public readonly String Revision;
        public readonly String Description;
        public readonly Boolean Selectable;
        public readonly Boolean CancelNotPassed;
        public readonly String TestMeasurementIDs;

        private Group(String id, String revision, String description, Boolean selectable, Boolean cancelNotPassed, String testMeasurementIDs) {
            ID = id;
            Revision = revision;
            Description = description;
            Selectable = selectable;
            CancelNotPassed = cancelNotPassed;
            TestMeasurementIDs = testMeasurementIDs;
        }

        public static Dictionary<String, Group> Get() {
            TestGroupsSection testGroupSection = (TestGroupsSection)ConfigurationManager.GetSection(TestGroupsSection.ClassName);
            TestGroups testGroups = testGroupSection.TestGroups;
            Dictionary<String, Group> dictionary = new Dictionary<String, Group>();
            foreach (TestGroup tg in testGroups) dictionary.Add(tg.ID, new Group(tg.ID, tg.Revision, tg.Description, tg.Selectable, tg.CancelNotPassed, tg.TestMeasurementIDs));
            return dictionary;
        }

        public static Group Get(String TestGroupID) { return Get()[TestGroupID]; }
    }

    public class Measurement {
        public readonly String ID;
        public readonly String Revision;
        public readonly String Description;
        public readonly String ClassName;
        public readonly Object ClassObject;
        public readonly Boolean CancelNotPassed;
        public String GroupID { get; set; } = String.Empty; // Determined pre-test.
        public String Value { get; set; } = String.Empty; // Determined during test.
        public EVENTS TestEvent { get; set; } = EVENTS.UNSET; // Determined post-test.
        public StringBuilder Message { get; set; } = new StringBuilder(); // Determined during test.

        private Measurement(String id, String revision, String description, String className, Boolean cancelNotPassed, String arguments) {
            ID = id;
            Revision = revision;
            Description = description;
            ClassName = className;
            ClassObject = Activator.CreateInstance(Type.GetType(GetType().Namespace + "." + ClassName), new Object[] { ID, arguments });
            CancelNotPassed = cancelNotPassed;
            if (String.Equals(ClassName, MeasurementNumeric.ClassName)) Value = Double.NaN.ToString();
        }

        public static Dictionary<String, Measurement> Get() {
            TestMeasurementsSection testMeasurementsSection = (TestMeasurementsSection)ConfigurationManager.GetSection(TestMeasurementsSection.ClassName);
            TestMeasurements testMeasurements = testMeasurementsSection.TestMeasurements;
            Dictionary<String, Measurement> dictionary = new Dictionary<String, Measurement>();
            foreach (TestMeasurement tm in testMeasurements) try {
                    dictionary.Add(tm.ID, new Measurement(tm.ID, tm.Revision, tm.Description, tm.ClassName, tm.CancelNotPassed, tm.Arguments));
                } catch (Exception e) {
                    StringBuilder sb = new StringBuilder(Environment.NewLine);
                    sb.AppendLine($"App.config issue with TestMeasurement:");
                    sb.AppendLine($"   ID              : {tm.ID}");
                    sb.AppendLine($"   Revision        : {tm.Revision}");
                    sb.AppendLine($"   Description     : {tm.Description}");
                    sb.AppendLine($"   ClassName       : {tm.ClassName}");
                    sb.AppendLine($"   CancelNotPassed : {tm.CancelNotPassed}");
                    sb.AppendLine($"   Arguments       : {tm.Arguments}{Environment.NewLine}");
                    sb.AppendLine($"Exception Message(s):");
                    sb.AppendLine($"{e}{Environment.NewLine}");
                    throw new ArgumentException(sb.ToString());
                }
            return dictionary;
        }

        public static Measurement Get(String TestMeasurementID) { return Get()[TestMeasurementID]; }
    }
}

