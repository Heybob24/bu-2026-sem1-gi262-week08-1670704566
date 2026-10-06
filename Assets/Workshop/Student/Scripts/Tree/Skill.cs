using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill
{
    public string name;
    public bool isUnlocked;
    public bool isAvailable;
    public List<Skill> nextSkills;


    public Skill(string name)
    {
        this.name = name;
        this.isUnlocked = false;
        this.nextSkills = new List<Skill>();
    }

    public void Unlock()
    {
        if (!isAvailable)
        {
            throw new System.Exception("Skill is not available to unlock.");
        }

        if (isUnlocked)
        {
            Debug.Log($"Skill {name} is already unlocked.");
            return;
        }

        isUnlocked = true;
        for (int i = 0; i < nextSkills.Count; i++)
        {
            nextSkills[i].isAvailable = true;
        }
    }


    public void PrintSkillTree()
    {
        // 6. log the name of the skill, isAvailable, and isUnlocked
        Debug.Log($"Skill: {name}, Available: {isAvailable}, Unlocked: {isUnlocked}");
        for (int i = 0; i < nextSkills.Count; i++)
        {
            nextSkills[i].PrintSkillTree();
        }
    }

    public void PrintSkillTreeHierarchy(string indent)
    {
        // 7. log the name of the skill, isAvailable, and isUnlocked with indentation
        // and call PrintSkillTreeHierarchy() on all nextSkills
        Debug.Log($"{indent}Skill: {name}, Available: {isAvailable}, Unlocked: {isUnlocked}");
        foreach (Skill skill in nextSkills)
        {
            skill.PrintSkillTreeHierarchy(indent + "====");
        }

    }

}

public class SkillTree
{
    public Skill rootSkill;

    public SkillTree(Skill rootSkill)
    {
        this.rootSkill = rootSkill;
    }
}

